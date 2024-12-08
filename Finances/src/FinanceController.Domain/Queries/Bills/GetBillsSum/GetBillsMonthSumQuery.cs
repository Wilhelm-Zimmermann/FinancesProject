using FinanceController.Domain.Commands.Contracts;

namespace FinanceController.Domain.Queries.Bills.GetBillsSum;

public class GetBillsMonthSumQuery : ICommand
{
    public DateTime EffectiveDate { get; set; }
    public Guid BillTypeId { get; set; }
    public Guid UserId { get; set; }
}