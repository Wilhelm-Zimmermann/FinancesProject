using FinanceController.Domain.Handlers;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Infra.Repositories;
using FinanceController.Domain.Repositories.Contracts;
using FinanceController.Domain.RequestHelpers;
using FinanceController.Domain.RequestHelpers.Implementations;
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

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // SERVICES
            builder.Services.AddSingleton<IUserService, UserService>();

            // REPOSITORIES
            builder.Services.AddScoped<IBillTypeRepository, BillTypeRepository>();
            builder.Services.AddScoped<IBillRepository, BillRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // HANDLERS
            builder.Services.AddScoped<BillTypeHandler, BillTypeHandler>();
            builder.Services.AddScoped<BillHandler, BillHandler>();
            builder.Services.AddScoped<UserHandler, UserHandler>();
        }
    }
}
