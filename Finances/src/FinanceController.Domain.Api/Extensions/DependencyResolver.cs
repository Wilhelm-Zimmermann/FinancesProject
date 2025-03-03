using FinanceController.Domain.Api.Utils;
using FinanceController.Domain.Handlers;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Infra.Jobs;
using FinanceController.Domain.Infra.Repositories;
using FinanceController.Domain.Jobs.Handlers;
using FinanceController.Domain.Repositories.Contracts;
using FinanceController.Domain.RequestHelpers;
using FinanceController.Domain.RequestHelpers.Implementations;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

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
            builder.Services.AddScoped<BillTypeHandler>();
            builder.Services.AddScoped<BillHandler>();
            builder.Services.AddScoped<UserHandler>();

            // Job Handlers
            builder.Services.AddScoped<BillJobHandler>();
            builder.Services.AddScoped<CreateRecurringBillsJob>();
        }

        public static void AddHangFire(this WebApplicationBuilder builder)
        {
                        // Hangfire configs
            builder.Services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(config => config.UseNpgsqlConnection(builder.Configuration.GetConnectionString("HangfireConnection"))));
            
            builder.Services.AddHangfireServer();
            var sqlConnection = new NpgSqlConnection(builder.Configuration.GetConnectionString("HangfireConnection"));
            JobStorage.Current = new PostgreSqlStorage(sqlConnection);
        }

    }
}
