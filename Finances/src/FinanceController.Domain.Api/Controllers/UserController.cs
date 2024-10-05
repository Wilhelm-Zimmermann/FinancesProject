using FinanceController.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FinanceController.Domain.Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<GenericCommandResult>> CreateUser()
    {
        return new GenericCommandResult(true, "message", new {});
    }
}
