using Hangfire;
using Hangfire.Common;

namespace FinanceController.Domain.Infra.Jobs;
public class CreateRecurringBills : IJob
{
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
    }
}
