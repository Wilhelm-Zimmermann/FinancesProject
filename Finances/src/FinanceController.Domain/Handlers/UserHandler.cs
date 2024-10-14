using AutoMapper;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Commands.Users;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Handlers.Contracts;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace FinanceController.Domain.Handlers;
public class UserHandler(IUserRepository userRepository, IPrivilegeRepository privilegeRepository, IMapper mapper, ILogger<UserHandler> logger) : IHandler<CreateUserCommand>, IHandler<CreateUserFromRouteCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPrivilegeRepository _privilegeRepository = privilegeRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<UserHandler> _logger = logger;

    public async Task<ICommandResult> Handle(CreateUserCommand command)
    {
        var user = _mapper.Map<User>(command);
        await _userRepository.CreateUser(user);

        _logger.LogInformation("User from identity server Created successfully");
        return new GenericCommandResult(true, "usuário criado com sucesso", new {});
    }

    public async Task<ICommandResult> Handle(CreateUserFromRouteCommand command)
    {
        var user = new User(command.Email, command.Email, Guid.NewGuid());
        foreach (var privilegeId in command.Privileges)
        {
            var privilege = await _privilegeRepository.GetById(privilegeId);
            if (privilege != null)
            {
                user.Privileges.Add(privilege);
            } 
        }
        await _userRepository.CreateUser(user);
        return new GenericCommandResult(true, "usuário criado com sucesso", user);
    }
}
