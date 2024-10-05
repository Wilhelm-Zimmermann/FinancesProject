using FinanceController.Domain.Infra.Consumers;
using MassTransit;

namespace FinanceController.Domain.Api.Extensions;

public static class MassTransitConfig
{
    public static void ResolveMassTransitDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(x =>
        {
            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("finance", false));
            x.AddConsumer<CreateUserConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(builder.Configuration["RabbitMq:Host"], "/", host =>
                {
                    host.Username(builder.Configuration.GetValue("RabbitMq:Username", "guest"));
                    host.Username(builder.Configuration.GetValue("RabbitMq:Password", "guest"));
                });
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}
