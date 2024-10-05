using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinanceController.Domain.Api.Authentication;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public class Authorize : Attribute, IAsyncActionFilter
{
    public string Privilege { get; set; } = "";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var scopeFactory = context.HttpContext.RequestServices.GetRequiredService<IServiceScopeFactory>();
        using var scope = scopeFactory.CreateScope();

        var permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();
        var userId = context.HttpContext.Items["UserId"];

        if(userId is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var isAuthorized = await permissionService.IsAuthorize((Guid)userId, Privilege);

        if (!isAuthorized)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
