using Hangfire.Common;
using Hangfire.Logging;
using Hangfire.Server;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceController.Domain.Infra.Jobs;
public class JobLoggerAttribute : JobFilterAttribute, IServerFilter
{
    private readonly ILogger<JobLoggerAttribute> _logger;
    private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

    public JobLoggerAttribute()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILogger<JobLoggerAttribute>>();
        Logger.InfoFormat("Job is being executed.");
    }

    public void OnPerformed(PerformedContext context)
    {
        //_logger.LogInformation(message.ToString());
        var message = $"Job `{context.BackgroundJob.Job.Type.Name}` has been performed";
        Logger.InfoFormat(message.ToString());
    }

    public void OnPerforming(PerformingContext context)
    {
        //_logger.LogInformation($"An error occurred in job");
        Logger.InfoFormat($"An error occurred in job {context.BackgroundJob.Job.Args}");
    }
}
