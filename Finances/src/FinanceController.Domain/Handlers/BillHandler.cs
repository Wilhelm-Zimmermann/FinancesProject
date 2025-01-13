using AutoMapper;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Bills;
using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Handlers.Contracts;
using FinanceController.Domain.Queries.Bills;
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
            command.UserId = _userService.UserId;
            var bill = _mapper.Map<Bill>(command);
            await _billRepository.CreateBill(bill);
            return new GenericCommandResult(true, "Bill created sucessfully", _mapper.Map<BillsDto>(bill));
        }
        
        public async Task<ICommandResult> Handle(UpdateBillCommand command)
        {
            command.UserId = _userService.UserId;
            await _billRepository.UpdateBill(command);
            
            return new GenericCommandResult(true, "Bill updated sucessfully", _mapper.Map<BillsDto>(command));
        }

        public async Task<ICommandResult> Handle(GetBillsSumQuery command)
        {
            var userId = _userService.UserId;
            var billsSum = await _billRepository.SumAllByUser(userId, command);

            return new GenericCommandResult(true, "Bills sum", billsSum);
        }
    }
}
