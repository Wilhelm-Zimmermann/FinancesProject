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
        Task<IEnumerable<BillsDto>> GetAllBills();
        Task DeleteBill(Guid id);
        Task<IEnumerable<BillsDto>> ListBillsByUserId(Guid userId);
        Task<double> SumAllByUserIdAndBillType(Guid userId, Guid billTypeId);
        Task<double> SumAllByUserIdAndBillTypeMonthly(GetBillsMonthSumQuery command);
    }
}
