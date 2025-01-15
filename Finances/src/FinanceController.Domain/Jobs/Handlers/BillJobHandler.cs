using FinanceController.Domain.Jobs.Commands.Bills;
using FinanceController.Domain.Jobs.Handlers.Contracts;
using FinanceController.Domain.Repositories.Contracts;

namespace FinanceController.Domain.Jobs.Handlers;
public class BillJobHandler : IJobHandler<CreateBillJobCommand>
{
    private readonly IBillRepository _billRepository;

    public BillJobHandler(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task Handle(CreateBillJobCommand jobCommand)
    {

        return;
    }
}
