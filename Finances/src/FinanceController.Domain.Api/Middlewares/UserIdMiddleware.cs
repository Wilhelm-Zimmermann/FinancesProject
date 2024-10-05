using FinanceController.Domain.RequestHelpers;
using System.IdentityModel.Tokens.Jwt;

namespace FinanceController.Domain.Api.Middlewares;

public class UserIdMiddleware
{
    private readonly RequestDelegate _next;

    public UserIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            var userId = GetUserIdFromToken(token);
            if (!string.IsNullOrEmpty(userId))
            {
                userService.UserId = Guid.Parse(userId);
                context.Items["UserId"] = Guid.Parse(userId);
            }
        }

        await _next(context);
    }
    private string GetUserIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

        if (jwtToken == null)
            return null;

        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub");

        return userIdClaim?.Value;
    }

}
