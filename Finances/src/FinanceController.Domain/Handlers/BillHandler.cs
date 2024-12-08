using AutoMapper;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Bills;
using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Handlers.Contracts;
using FinanceController.Domain.Queries.Bills.GetBillsSum;
using FinanceController.Domain.Repositories.Contracts;
using FinanceController.Domain.RequestHelpers;

namespace FinanceController.Domain.Handlers
{
    public class BillHandler : 
        IHandler<CreateBillCommand>,
        IHandler<UpdateBillCommand>,
        IHandler<GetBillsSumQuery>
    {
        private readonly IBillRepository _billRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public BillHandler(IBillRepository billRepository, IUserService userService, IMapper mapper)
        {
            _billRepository = billRepository;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<ICommandResult> Handle(CreateBillCommand command)
        {
            var userId = _userService.UserId;
            var bill = new Bill(command.Name, command.Price, command.Description, command.PaidDate, command.BillTypeId, userId, command.EffectiveDate);
            await _billRepository.CreateBill(bill);
            return new GenericCommandResult(true, "Bill created sucessfully", command);
        }
        
        public async Task<ICommandResult> Handle(UpdateBillCommand command)
        {
            await _billRepository.UpdateBill(command);
            
            return new GenericCommandResult(true, "Bill updated sucessfully", command);
        }

        public async Task<ICommandResult> Handle(GetBillsSumQuery command)
        {
            var userId = _userService.UserId;
            var billsSum = await _billRepository.SumAllByUserIdAndBillType(userId, command.BillTypeId);

            return new GenericCommandResult(true, "Bills sum", billsSum);
        }

        public async Task<ICommandResult> Handle(GetBillsMonthSumQuery command)
        {
            command.UserId = _userService.UserId;
            var billsSum = await _billRepository.SumAllByUserIdAndBillTypeMonthly(command);

            return new GenericCommandResult(true, "Bills monthly sum", billsSum);
        }
    }
}
