using FinanceController.Domain.Entities;
using System.Linq.Expressions;

namespace FinanceController.Domain.Queries.Users
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetUserById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<User, bool>> GetUserByEmail(string email)
        {
            return x => x.Email == email;
        }
    }
}
