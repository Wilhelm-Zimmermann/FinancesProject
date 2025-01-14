using FinanceController.Domain.Handlers;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Infra.Repositories;
using FinanceController.Domain.Repositories.Contracts;
using FinanceController.Domain.RequestHelpers;
using FinanceController.Domain.RequestHelpers.Implementations;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Api.Extensions
{
    public static class DependencyResolver
    {
        public static void Resolve(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ApiDatabase");
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString, config =>
                {
                    config.MigrationsAssembly("FinanceController.Domain.Api");
                });
            });

            // Hangfire configs
            builder.Services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(config => config.UseNpgsqlConnection(builder.Configuration.GetConnectionString("HangfireConnection"))));
            builder.Services.AddHangfireServer();

            // Auto Mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // SERVICES
            builder.Services.AddScoped<IUserService, UserService>();

            // REPOSITORIES
            builder.Services.AddScoped<IBillTypeRepository, BillTypeRepository>();
            builder.Services.AddScoped<IBillRepository, BillRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPrivilegeRepository, PrivilegeRepository>();

            // HANDLERS
            builder.Services.AddScoped<BillTypeHandler, BillTypeHandler>();
            builder.Services.AddScoped<BillHandler, BillHandler>();
            builder.Services.AddScoped<UserHandler, UserHandler>();
        }
    }
}
