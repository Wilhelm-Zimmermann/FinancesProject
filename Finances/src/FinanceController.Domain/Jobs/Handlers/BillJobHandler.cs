using AutoMapper;
using FinanceController.Domain.Commands.Bills;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Enums.Bills;
using FinanceController.Domain.Jobs.Commands.Bills;
using FinanceController.Domain.Jobs.Handlers.Contracts;
using FinanceController.Domain.Repositories.Contracts;

namespace FinanceController.Domain.Jobs.Handlers;
public class BillJobHandler : IJobHandler<CreateBillJobCommand>
{
    private readonly IBillRepository _billRepository;
    private readonly IMapper _mapper;

    public BillJobHandler(IBillRepository billRepository, IMapper mapper)
    {
        _billRepository = billRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateBillJobCommand jobCommand)
    {
        var billsToRecreate = await _billRepository.GetRecurringBills("Montlhy");
        foreach (var bill in billsToRecreate)
        {
            var effectiveDate = bill.EffectiveDate = bill.EffectiveDate.AddMonths(1);
            var newBill = new Bill()
            {
                EffectiveDate = effectiveDate,
                BillType = bill.BillType,
                BillTypeId = bill.BillTypeId,
                Currency = bill.Currency,
                Description = bill.Description,
                IsRecurring = bill.IsRecurring,
                Name = bill.Name,
                PaidDate = null,
                PaymentStatus = EPaymentStatus.Pending,
                Price = bill.Price,
                RecurrencePattern = bill.RecurrencePattern,
                TransactionType = bill.TransactionType,
                UserId = bill.UserId,
                User = bill.User,
            };
            bill.IsRecurring = false;
            await _billRepository.CreateBill(newBill);
            await _billRepository.UpdateBill(_mapper.Map<UpdateBillCommand>(bill));
        }
        return;
    }
}
