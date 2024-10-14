using FinanceController.Domain.Entities;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Infra.Repositories
{
    public class PrivilegeRepository : IPrivilegeRepository
    {
        private readonly DatabaseContext _context;

        public PrivilegeRepository(DatabaseContext context) 
        { 
           _context = context;
        }

        public async Task<Privilege> GetById(Guid id)
        {
            return await _context.Privileges.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
