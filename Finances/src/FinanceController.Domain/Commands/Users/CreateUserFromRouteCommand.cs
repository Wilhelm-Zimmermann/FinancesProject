using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Entities;

namespace FinanceController.Domain.Commands.Users;
public class CreateUserFromRouteCommand : ICommand
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Guid[] Privileges { get; set; }

    public CreateUserFromRouteCommand(Guid? id, string name, string email, Guid[] privileges)
    {
        Id = id;
        Name = name;
        Email = email;
        Privileges = privileges;
    }
}
