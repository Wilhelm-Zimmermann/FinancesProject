using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Entities;

namespace FinanceController.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public CreateUserCommand(Guid id, string name, string email)
        {
            Name = name;
            Email = email;
            Id = id;
        }
    }
}
