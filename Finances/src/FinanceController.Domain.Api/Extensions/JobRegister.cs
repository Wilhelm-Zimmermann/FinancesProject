using FinanceController.Domain.Infra.Jobs;
using System.Reflection;

namespace FinanceController.Domain.Api.Extensions;

public static class JobRegister
{
    public static void RegisterAllJobs(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var jobType = typeof(IJob);
        var jobImplementations = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        foreach (var job in jobImplementations)
        {
            if (typeof(IJob).IsAssignableFrom(job))
            {
                var instance = serviceProvider.GetRequiredService(job) as IJob;
                instance?.Register();
            }
        }
    }
}
