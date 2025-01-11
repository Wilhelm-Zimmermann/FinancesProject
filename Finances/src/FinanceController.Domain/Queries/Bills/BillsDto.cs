using FinanceController.Domain.Queries.BillsTypes;

namespace FinanceController.Domain.Queries.Bills;
public class BillsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string TransactionType { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public Guid BillTypeId { get; set; }
    public BillTypeDto BillType { get; set; }
    public Guid UserId { get; set; }
}
