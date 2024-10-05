using FinanceController.Domain.Entities;
using FinanceController.Domain.Infra.Commons.Constants;
using FinanceController.Domain.Infra.Contexts;

namespace FinanceController.Domain.Api.Seed;

public class PrivilegeSeed : ISeeder
{
    public static void EnsureSeed(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        if (context.Privileges.Any())
        {
            return;
        }

        var billDomain = context.Domains.FirstOrDefault(x => x.Name == "Bill");
        var billDomainType = context.Domains.FirstOrDefault(x => x.Name == "BillType");

        if(billDomain != null)
        {
            context.Privileges.Add(new Privilege(Privileges.BillCreate, billDomain.Id));
            context.Privileges.Add(new Privilege(Privileges.BillUpdate, billDomain.Id));
            context.Privileges.Add(new Privilege(Privileges.BillDelete, billDomain.Id));
            context.Privileges.Add(new Privilege(Privileges.BillRead, billDomain.Id));
        }

        if(billDomainType != null)
        {
            context.Privileges.Add(new Privilege(Privileges.BillTypeCreate, billDomainType.Id));
            context.Privileges.Add(new Privilege(Privileges.BillTypeUpdate, billDomainType.Id));
            context.Privileges.Add(new Privilege(Privileges.BillTypeDelete, billDomainType.Id));
            context.Privileges.Add(new Privilege(Privileges.BillTypeRead, billDomainType.Id));
        }

        context.SaveChanges();
    }
}
