using FinanceController.Domain.Entities;

namespace FinanceController.Domain.Repositories.Contracts
{
    public interface IPrivilegeRepository
    {
        Task<Privilege> GetById(Guid id);
    }
}
