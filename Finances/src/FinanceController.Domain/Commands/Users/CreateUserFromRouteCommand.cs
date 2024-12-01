using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Entities;

namespace FinanceController.Domain.Commands.Users;
public class CreateUserFromRouteCommand : ICommand
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid[] Privileges { get; set; }

    public CreateUserFromRouteCommand(string name, string email, string password, Guid[] privileges)
    {
        Name = name;
        Email = email;
        Privileges = privileges;
        Password = password;
    }
}
