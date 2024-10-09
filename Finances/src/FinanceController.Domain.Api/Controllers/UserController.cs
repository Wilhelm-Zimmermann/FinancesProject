using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Users;
using FinanceController.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace FinanceController.Domain.Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<GenericCommandResult>> CreateUser([FromServices] UserHandler handler, [FromBody] CreateUserFromRouteCommand userCommand)
    {
        var user = (GenericCommandResult) await handler.Handle(userCommand);
        return user;
    }
}
