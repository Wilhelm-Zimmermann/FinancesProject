using FinanceController.Domain.Entities;

namespace FinanceController.Domain.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<IList<User>> GetAllUsers();
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
    }
}
