using FinanceController.Domain.Enums;

namespace FinanceController.Domain.Queries.Bills;

public class GetAllBillsQuery
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ETransactionType? TransactionType { get; set; }
    public Guid? BillTypeId { get; set; }
}