using FinanceController.Domain.Api.Authentication;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Users;
using FinanceController.Domain.Handlers;
using FinanceController.Domain.Infra.Commons.Constants;
using Microsoft.AspNetCore.Mvc;

namespace FinanceController.Domain.Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Authorize(Privilege = Privileges.UserCreate)]
    public async Task<ActionResult<GenericCommandResult>> CreateUser([FromServices] UserHandler handler, [FromBody] CreateUserFromRouteCommand command)
    {
        var user = (GenericCommandResult) await handler.Handle(command);
        return user;
    }
}
