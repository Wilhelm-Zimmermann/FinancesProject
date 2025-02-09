using FinanceController.Domain.Infra.Jobs;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinanceController.Domain.Infra;
public static class JobsRegistration
{
    public static void RegisterInfraJobs(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        var jobImplementations = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        foreach (var jobType in jobImplementations)
        {
            if (typeof(IJob).IsAssignableFrom(jobType) && jobType != typeof(IJob))
            {
                var jobInstance = (IJob)serviceProvider.GetService(jobType);

                jobInstance?.Register();
            }
        }
    }
}
