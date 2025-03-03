using FinanceController.Domain.Jobs.Handlers;
using FinanceController.Domain.Jobs.Commands.Bills;
using Hangfire;
using Hangfire.Common;

namespace FinanceController.Domain.Infra.Jobs;

[JobLogger]
public class CreateRecurringBillsJob : IJob
{
    private readonly BillJobHandler _billJobHandler;

    public CreateRecurringBillsJob(BillJobHandler billJobHandler)
    {
        _billJobHandler = billJobHandler;
    }

    public void Register()
    {
        var manager = new RecurringJobManager();
        var options = new RecurringJobOptions
        {
        };

        manager.AddOrUpdate("createrecurringbills", Job.FromExpression(() => Execute()), "* 10 * * * *", options);
    }
    public async Task Execute()
    {
        try
        {
            await _billJobHandler.Handle(new CreateBillJobCommand());
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
