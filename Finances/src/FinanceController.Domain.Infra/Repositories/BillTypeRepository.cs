using FinanceController.Domain.Entities;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Infra.Repositories
{
    public class BillTypeRepository : IBillTypeRepository
    {
        private DatabaseContext _context;

        public BillTypeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateBill(BillType billType)
        {
            _context.BillTypes.Add(billType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBillType(Guid id)
        {
            var billTypeToDelete = await _context.BillTypes.FindAsync(id);

            if(billTypeToDelete != null)
            {
                _context.BillTypes.Remove(billTypeToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BillType>> GetAllBillTypes()
        {
            return await _context.BillTypes.ToListAsync();
        }
    }
}
