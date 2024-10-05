
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.RequestHelpers;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Api.Authentication;

public class PermissionService : IPermissionService
{
    private readonly IServiceScopeFactory _scope;

    public PermissionService(IServiceScopeFactory scope)
    {
        _scope = scope;
    }

    public async Task<bool> IsAuthorize(Guid userId, string privilege)
    {
        using var scope = _scope.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        var user = await context.Users
            .Include(u => u.Privileges.Where(x => x.Name == privilege))
            .FirstOrDefaultAsync(x => x.Id == userId);
        
        if(user != null)
        {
            var userPrivilege = user.Privileges.FirstOrDefault();

            if(userPrivilege != null)
            {
                return true;
            }
        }

        return false;
    }
}
