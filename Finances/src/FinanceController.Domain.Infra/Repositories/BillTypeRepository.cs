using AutoMapper;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Queries.BillsTypes;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Infra.Repositories
{
    public class BillTypeRepository : IBillTypeRepository
    {
        private DatabaseContext _context;
        private readonly IMapper _mapper;

        public BillTypeRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<IEnumerable<BillTypeDto>> GetAllBillTypes()
        {
            var billTypes = await _context.BillTypes.ToListAsync();
            return _mapper.Map<BillTypeDto[]>(billTypes);
        }
    }
}
