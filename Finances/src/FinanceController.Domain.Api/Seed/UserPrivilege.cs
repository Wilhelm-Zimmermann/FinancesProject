using FinanceController.Domain.Infra.Commons.Constants;
using FinanceController.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Api.Seed;

public class UserPrivilege
{
    public static void EnsureSeedData(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        var privileges = context.Privileges.ToList();
        var user = context.Users.Include(x => x.Privileges).FirstOrDefault();
        
        if (user is null || user.Privileges.Any())
        {
            return;
        }

        foreach (var privilege in privileges)
        {
            user.Privileges.Add(privilege);
        }

        context.SaveChanges();
    }
}
