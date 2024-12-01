using System.Security.Claims;
using FinancesLibrary.Events;
using IdentityModel;
using IdentityServer.Models;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Consumers;

public class CreateUserFromRouteConsumer : IConsumer<CreateUserFromRouteEvent>
{
    private readonly ILogger<CreateUserFromRouteConsumer> _logger;
    private readonly UserManager<ApplicationUser> _userMgr;

    public CreateUserFromRouteConsumer(ILogger<CreateUserFromRouteConsumer> logger, UserManager<ApplicationUser> userMgr)
    {
        _logger = logger;
        _userMgr = userMgr;
    }

    public async Task Consume(ConsumeContext<CreateUserFromRouteEvent> context)
    {
        var user = context.Message;
        var newUser = new ApplicationUser()
        {
            UserName = user.Name,
            Email = user.Email,
        };
        var result = _userMgr.CreateAsync(newUser, user.Password).Result;
        if (!result.Succeeded)
        {
            _logger.LogError("Failed to create user");
        }

        result = _userMgr.AddClaimsAsync(newUser, new Claim[]
        {
            new(JwtClaimTypes.GivenName, user.Name),
        }).Result;
        
        if (!result.Succeeded)
        {
           _logger.LogError("Failed to create user");
        }
    }
}