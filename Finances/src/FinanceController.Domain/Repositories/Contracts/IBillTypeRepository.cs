using FinanceController.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceController.Domain.Repositories.Contracts
{
    public interface IBillTypeRepository
    {
        Task CreateBill(BillType billType);
        Task<IEnumerable<BillType>> GetAllBillTypes();
        Task DeleteBillType(Guid id);
    }
}
