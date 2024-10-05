using FinanceController.Domain.Entities;

namespace FinanceController.Domain.Queries.Bills;
public class BillsDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public DateTime PaidDate { get; set; }

    public Guid BillTypeId { get; set; }

    public Guid UserId { get; set; }
}
