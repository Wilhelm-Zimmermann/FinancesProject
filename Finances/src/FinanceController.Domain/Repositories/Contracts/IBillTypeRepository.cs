using FinanceController.Domain.Entities;
using FinanceController.Domain.Queries.BillsTypes;

namespace FinanceController.Domain.Repositories.Contracts
{
    public interface IBillTypeRepository
    {
        Task CreateBill(BillType billType);
        Task<IEnumerable<BillTypeDto>> GetAllBillTypes();
        Task DeleteBillType(Guid id);
    }
}
