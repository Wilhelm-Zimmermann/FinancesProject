
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
            .Include(x => x.Privileges)
            .FirstOrDefaultAsync(x => x.Id == userId && x.Privileges.Any(p => p.Name == privilege));
        
        if(user != null) return true;

        return false;
    }
}
