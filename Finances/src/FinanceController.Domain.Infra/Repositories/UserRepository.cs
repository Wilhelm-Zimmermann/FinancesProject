using FinanceController.Domain.Entities;
using FinanceController.Domain.Infra.Contexts;
using FinanceController.Domain.Queries.Users;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinanceController.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(UserQueries.GetUserById(id));

            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(UserQueries.GetUserByEmail(email));
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(UserQueries.GetUserById(id));
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
