using FinanceController.Domain.Enums.Bills;
using FinanceController.Domain.Enums;
using FinanceController.Domain.Jobs.Commands.Contracts;

namespace FinanceController.Domain.Jobs.Commands.Bills;
public class CreateBillJobCommand : IJobCommand
{
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
    public Guid? UserId { get; set; }

    public CreateBillJobCommand()
    {
    }

    public CreateBillJobCommand(string name, decimal price, bool isRecurring, string? description, string? recurrencePattern, ETransactionType transactionType, EPaymentStatus paymentStatus, ECurrency currency, DateTime? paidDate, DateTime effectiveDate, Guid billTypeId, Guid? userId)
    {
        Name = name;
        Price = price;
        IsRecurring = isRecurring;
        Description = description;
        RecurrencePattern = recurrencePattern;
        TransactionType = transactionType;
        PaymentStatus = paymentStatus;
        Currency = currency;
        PaidDate = paidDate;
        EffectiveDate = effectiveDate;
        BillTypeId = billTypeId;
        UserId = userId;
    }
}
