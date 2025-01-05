using FinanceController.Domain.Commands.Bills;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Queries.Bills;
using FinanceController.Domain.Queries.Bills.GetBillsSum;

namespace FinanceController.Domain.Repositories.Contracts
{
    public interface IBillRepository
    {
        Task CreateBill(Bill command);
        Task UpdateBill(UpdateBillCommand command);
        Task<BillsDto> GetBillById(Guid id);
        Task<IEnumerable<BillsDto>> GetAllBills();
        Task DeleteBill(Guid id);
        Task<IEnumerable<BillsDto>> ListBillsByUserId(GetAllBillsQuery billQuery, Guid userId);
        Task<double> SumAllByUser(Guid userId, GetBillsSumQuery billsQuery);
    }
}
