using FinanceController.Domain.Api.Authentication;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Handlers;
using FinanceController.Domain.Infra.Commons.Constants;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinanceController.Domain.Api.Controllers
{
    [ApiController]
    [Route("api/v1/billType")]
    public class BillTypeController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize(Privilege = Privileges.BillTypeCreate)]
        public async Task<ActionResult<GenericCommandResult>> CreateBillType([FromBody] CreateBillTypeCommand command, [FromServices] BillTypeHandler handler)
        {
            var result = await handler.Handle(command);

            return StatusCode(201, result);
        }

        [HttpGet]
        [Route("list")]
        [Authorize(Privilege = Privileges.BillTypeRead)]
        public async Task<ActionResult<GenericCommandResult>> ListAllBillTypes([FromServices] IBillTypeRepository repository)
        {
            var result = await repository.GetAllBillTypes();

            return StatusCode(200, result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Privilege = Privileges.BillTypeDelete)]
        public async Task<ActionResult<GenericCommandResult>> DeleteBillType([FromRoute] Guid id, [FromServices] IBillTypeRepository repository)
        {
            await repository.DeleteBillType(id);

            var result = new GenericCommandResult(true, "Bill type deleted sucessfully", new { });

            return StatusCode(200, result);
        }
    }
}
