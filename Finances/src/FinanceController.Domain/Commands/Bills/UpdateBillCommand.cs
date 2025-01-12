using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Enums;

namespace FinanceController.Domain.Commands.Bills;

public class UpdateBillCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public ETransactionType TransactionType { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime EffectiveDate { get; private set; }
    public Guid BillTypeId { get; set; }

    public UpdateBillCommand(Guid id, string name, double price, string? description, ETransactionType transactionType, DateTime paidDate, Guid billTypeId, DateTime effectiveDate)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        TransactionType = transactionType;
        PaidDate = paidDate;
        BillTypeId = billTypeId;
        EffectiveDate = effectiveDate;
    }
}