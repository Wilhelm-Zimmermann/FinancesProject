﻿using FinanceController.Domain.Api.Authentication;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Bills;
using FinanceController.Domain.Handlers;
using FinanceController.Domain.Infra.Commons.Constants;
using FinanceController.Domain.Queries.Bills;
using FinanceController.Domain.Queries.Bills.GetBillsSum;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinanceController.Domain.Api.Controllers
{
    [ApiController]
    [Route("api/v1/bills")]
    public class BillController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize(Privilege = Privileges.BillCreate)]
        public async Task<ActionResult<GenericCommandResult>> CreateBill([FromBody] CreateBillCommand command, [FromServices] BillHandler handler)
        {
            var result = await handler.Handle(command);

            return StatusCode(201, result);
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Privilege = Privileges.BillUpdate)]
        public async Task<ActionResult<GenericCommandResult>> UpdateBill([FromBody] UpdateBillCommand command, [FromServices] BillHandler handler)
        {
            var result = await handler.Handle(command);
            return StatusCode(200, result);
        }

        [HttpGet]
        [Route("list")]
        [Authorize(Privilege = Privileges.BillRead)]
        public async Task<ActionResult<GenericCommandResult>> ListAllBills([FromServices] IBillRepository repository)
        {
            var bills = await repository.GetAllBills();
            var result = new GenericCommandResult(true, "Bills fetched", bills);

            return StatusCode(200, result);
        }

        [HttpGet]
        [Route("list/{id}")]
        [Authorize(Privilege = Privileges.BillRead)]
        public async Task<ActionResult<GenericCommandResult>> GetBillById(Guid id, [FromServices] IBillRepository repository)
        {
            var bill = await repository.GetBillById(id);
            var result = new GenericCommandResult(true, "Bill found", bill);

            return StatusCode(200, result);
        }

        [HttpGet]
        [Route("list/user-logged")]
        [Authorize(Privilege = Privileges.BillRead)]
        public async Task<ActionResult<GenericCommandResult>> ListLoggedUserBills([FromQuery] GetAllBillsQuery billsQuery, [FromServices] IBillRepository repository)
        {
            var userId = HttpContext.Items["UserId"];
            var bills = await repository.ListBillsByUserId(billsQuery, (Guid)userId);

            return Ok(new GenericCommandResult(true, "Bills fetched successfully", bills));
        }

        [HttpGet]
        [Route("sum")]
        [Authorize(Privilege = Privileges.BillRead)]
        public async Task<ActionResult<GenericCommandResult>> GetSumByUserIdAndBillType([FromQuery] GetBillsSumQuery query, [FromServices] BillHandler handler)
        {
            var billsSum = await handler.Handle(query);

            return Ok(billsSum);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Privilege = Privileges.BillDelete)]
        public async Task<ActionResult<GenericCommandResult>> DeleteBill([FromServices] IBillRepository repository, Guid id)
        {
            await repository.DeleteBill(id);

            return StatusCode(200, new GenericCommandResult(true, "Bill deleted sucessfully", new { }));
        }
    }
}
