using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceController.Domain.Commands.Bills;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Queries.Bills;
using FinanceController.Domain.Queries.Bills.GetBillsSum;
using FinanceController.Domain.Repositories.Contracts;
using FinanceController.Domain.Shared.Utils.Errors;
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

        public async Task UpdateBill(UpdateBillCommand command)
        {
            var bill = await _context.Bills.FindAsync(command.Id);
            
            if(bill is null) throw new AppError(404, "Bill not found");
            
            bill.Name = command.Name;
            bill.Price = command.Price;
            bill.Description = command.Description;
            bill.EffectiveDate = command.EffectiveDate;
            bill.PaidDate = command.PaidDate;  
            bill.BillTypeId = command.BillTypeId;
            bill.TransactionType = command.TransactionType.ToString();
            
            _context.Bills.Update(bill);
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

        public async Task<BillsDto> GetBillById(Guid id)
        {
            return await _context.Bills.Where(x => x.Id == id).ProjectTo<BillsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BillsDto>> ListBillsByUserId(GetAllBillsQuery billsQuery, Guid userId)
        {
            var billsQueryResult = _context.Bills
                .Where(x => x.UserId == userId);
            
            if (billsQuery.StartDate.HasValue && billsQuery.EndDate.HasValue)
            {
                billsQueryResult = billsQueryResult.Where(x => x.EffectiveDate >= billsQuery.StartDate && x.EffectiveDate <= billsQuery.EndDate);
            }

            if (billsQuery.BillTypeId.HasValue)
            {
                billsQueryResult = billsQueryResult.Where(x => x.BillTypeId == billsQuery.BillTypeId);
            }

            if (billsQuery.TransactionType.HasValue)
            {
                billsQueryResult = billsQueryResult.Where(x => x.TransactionType == billsQuery.TransactionType.ToString());
            }
            
            return await billsQueryResult
                .ProjectTo<BillsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();;
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
