using FinanceController.Domain.Api.Extensions;
using FinanceController.Domain.Api.Middlewares;
using FinanceController.Domain.Api.Seed;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigAuthorizationSettings();
builder.ResolveMassTransitDependencies();
builder.Resolve();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string allowedOrigins = "AllowAllOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrigins, policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// builder.Services.AddCors();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanceApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In= ParameterLocation.Header
            },
            new List<string> ()
        }
     });
});

var app = builder.Build();

// DomainSeed.EnsureSeed(app);
// PrivilegeSeed.EnsureSeed(app);
// UserPrivilege.EnsureSeedData(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<UserIdMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseRouting();
// app.UseHttpsRedirection();
app.UseCors(allowedOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
