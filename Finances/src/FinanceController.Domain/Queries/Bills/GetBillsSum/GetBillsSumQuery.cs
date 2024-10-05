using FinanceController.Domain.Commands.Contracts;

namespace FinanceController.Domain.Queries.Bills.GetBillsSum;
public class GetBillsSumQuery : ICommand
{
    public Guid BillTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
