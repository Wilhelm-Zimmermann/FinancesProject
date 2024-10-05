using FinanceController.Domain.Commands.Contracts;

namespace FinanceController.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
