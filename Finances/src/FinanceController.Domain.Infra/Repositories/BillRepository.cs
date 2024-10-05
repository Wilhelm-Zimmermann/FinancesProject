using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Queries.Bills;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Infra.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BillRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateBill(Bill command)
        {
            _context.Bills.Add(command);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBill(Guid id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if(bill != null)
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BillsDto>> GetAllBills()
        {
            return await _context.Bills
                .ProjectTo<BillsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<BillsDto>> ListBillsByUserId(Guid userId)
        {
            return await _context.Bills
                .Where(BillsQueries.ListBillsByUserId(userId))
                .ProjectTo<BillsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<double> SumAllByUserIdAndBillType(Guid userId, Guid billTypeId)
        {
            return await _context.Bills
                .Where(x => x.UserId == userId)
                .Where(x => x.BillTypeId == billTypeId)
                .SumAsync(x => x.Price);
        }
    }
}
