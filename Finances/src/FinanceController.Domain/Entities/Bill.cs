namespace FinanceController.Domain.Entities
{
    public class Bill : Base
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public DateTime PaidDate { get; private set; }

        public Guid BillTypeId { get; private set; }
        public BillType BillType { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Bill(string name, double price, string description, DateTime paidDate, Guid billTypeId, Guid userId)
        {
            Name = name;
            Price = price;
            Description = description;
            PaidDate = paidDate;
            BillTypeId = billTypeId;
            UserId = userId;
        }

        public void SetPaidDate(DateTime paidDate)
        {
            PaidDate = paidDate;
        }
    }
}
