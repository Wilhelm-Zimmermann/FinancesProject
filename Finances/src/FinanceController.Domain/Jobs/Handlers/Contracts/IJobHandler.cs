using FinanceController.Domain.Jobs.Commands.Contracts;

namespace FinanceController.Domain.Jobs.Handlers.Contracts;
public interface IJobHandler<T> where T : IJobCommand
{
    Task Handle(T jobCommand);
}
