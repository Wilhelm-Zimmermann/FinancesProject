using FinanceController.Domain.Enums;

namespace FinanceController.Domain.Entities
{
    public class Bill : Base
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string TransactionType { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime EffectiveDate { get; set; }

        public Guid BillTypeId { get; set; }
        public BillType BillType { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Bill() {}

        public Bill(string name, double price, string description, string transactionType, DateTime paidDate, Guid billTypeId, Guid userId, DateTime effectiveDate)
        {
            Name = name;
            Price = price;
            Description = description;
            TransactionType = transactionType;
            PaidDate = paidDate;
            BillTypeId = billTypeId;
            UserId = userId;
            EffectiveDate = effectiveDate;
        }

        public void SetPaidDate(DateTime paidDate)
        {
            PaidDate = paidDate;
        }
    }
}
