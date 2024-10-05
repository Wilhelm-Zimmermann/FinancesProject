
using FinanceController.Domain.Infra.Contexts;

namespace FinanceController.Domain.Api.Seed;

public class DomainSeed : ISeeder
{
    public static void EnsureSeed(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        if(context.Domains.Any())
        {
            return;
        }

        context.Domains.Add(new Entities.Domain("Bill"));
        context.Domains.Add(new Entities.Domain("BillType"));

        context.SaveChanges();
    }
}
