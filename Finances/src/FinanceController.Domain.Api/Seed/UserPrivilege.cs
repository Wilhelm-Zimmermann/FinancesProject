using FinanceController.Domain.Infra.Commons.Constants;
using FinanceController.Domain.Infra.Contexts;

namespace FinanceController.Domain.Api.Seed;

public class UserPrivilege
{
    public static void EnsureSeedData(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        var privileges = context.Privileges.ToList();
        var user = context.Users.FirstOrDefault();

        foreach (var privilege in privileges)
        {
            user.Privileges.Add(privilege);
        }

        context.SaveChanges();
    }
}
