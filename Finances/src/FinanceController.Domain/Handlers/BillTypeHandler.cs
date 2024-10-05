
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Handlers.Contracts;
using FinanceController.Domain.Repositories.Contracts;

namespace FinanceController.Domain.Handlers
{
    public class BillTypeHandler : IHandler<CreateBillTypeCommand>
    {
        private IBillTypeRepository _billTypeRepository;

        public BillTypeHandler(IBillTypeRepository billTypeRepository)
        {
            _billTypeRepository = billTypeRepository;
        }

        public async Task<ICommandResult> Handle(CreateBillTypeCommand command)
        {
            var billType = new BillType(command.Type);

            await _billTypeRepository.CreateBill(billType);

            return new GenericCommandResult(true, "Bill Type created successfully", billType);
        }
    }
}
