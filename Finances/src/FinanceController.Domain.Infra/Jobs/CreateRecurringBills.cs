using FinanceController.Domain.Jobs.Handlers;
using FinanceController.Domain.Jobs.Commands.Bills;
using Hangfire;
using Hangfire.Common;

namespace FinanceController.Domain.Infra.Jobs;
public class CreateRecurringBills : IJob
{
    private readonly BillJobHandler _billJobHandler;

    public CreateRecurringBills(BillJobHandler billJobHandler)
    {
        _billJobHandler = billJobHandler;
    }

    public void Register()
    {
        var manager = new RecurringJobManager();
        var options = new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.Local
        };

        manager.AddOrUpdate("createrecurringbils", Job.FromExpression(() => Execute()), Cron.Monthly(1, 0), options);
    }
    public async Task Execute()
    {
        Console.WriteLine("Creating Recurring bills....");
        await _billJobHandler.Handle(new CreateBillJobCommand());
    }
}
