using FinanceController.Domain.Entities;
using FinanceController.Domain.Queries.Bills;

namespace FinanceController.Domain.Repositories.Contracts
{
    public interface IBillRepository
    {
        Task CreateBill(Bill command);
        Task<IEnumerable<BillsDto>> GetAllBills();
        Task DeleteBill(Guid id);
        Task<IEnumerable<BillsDto>> ListBillsByUserId(Guid userId);
        Task<double> SumAllByUserIdAndBillType(Guid userId, Guid billTypeId);
    }
}
