namespace FinanceController.Domain.Entities
{
    public class BillType : Base
    {
        public string Type { get; set; }
        public IList<Bill> Bills { get; set; }

        public BillType(string type)
        {
            Type = type;
        }

        public void AddBill(Bill bill)
        {
            Bills.Add(bill);
        }

        public void RemoveBill(Bill bill)
        {
            Bills.Remove(bill);
        }
    }
}
