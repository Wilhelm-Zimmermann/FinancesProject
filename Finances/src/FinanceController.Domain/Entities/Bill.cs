using FinanceController.Domain.Enums;
using FinanceController.Domain.Enums.Bills;

namespace FinanceController.Domain.Entities
{
    public class Bill : Base
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
        public BillType BillType { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Bill() {}

        public Bill(string name, decimal price, bool isRecurring, string? description, string? recurrencePattern, ETransactionType transactionType, EPaymentStatus paymentStatus, ECurrency currency, DateTime? paidDate, DateTime effectiveDate, Guid billTypeId, Guid userId)
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

        public void SetPaidDate(DateTime paidDate)
        {
            PaidDate = paidDate;
        }
    }
}
