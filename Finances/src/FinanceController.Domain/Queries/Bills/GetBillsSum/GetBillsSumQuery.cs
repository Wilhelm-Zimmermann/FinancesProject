using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Enums;

namespace FinanceController.Domain.Queries.Bills.GetBillsSum;
public class GetBillsSumQuery : ICommand
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ETransactionType? TransactionType { get; set; }
    public Guid? BillTypeId { get; set; }
}
