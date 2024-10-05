using FinanceController.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Api.Seed;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();

        //var identityUser = context.
    }
}
