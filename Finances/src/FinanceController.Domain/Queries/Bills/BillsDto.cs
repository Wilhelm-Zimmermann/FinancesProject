using FinanceController.Domain.Enums.Bills;
using FinanceController.Domain.Enums;
using FinanceController.Domain.Queries.BillsTypes;

namespace FinanceController.Domain.Queries.Bills;
public class BillsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsRecurring { get; set; }
    public string? Description { get; set; }
    public string? RecurrencePattern { get; set; }
    public ETransactionType TransactionType { get; set; }
    public EPaymentStatus PaymentStatus { get; set; }
    public ECurrency Currency { get; set; }
    public DateTime? PaidDate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public Guid BillTypeId { get; set; }
    public Guid UserId { get; set; }
    public BillTypeDto BillType { get; set; }
}
