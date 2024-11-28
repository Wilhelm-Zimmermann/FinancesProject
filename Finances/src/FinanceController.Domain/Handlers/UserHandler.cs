using AutoMapper;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Commands.Users;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Handlers.Contracts;
using FinanceController.Domain.Repositories.Contracts;
using MassTransit.Transports;
using Microsoft.Extensions.Logging;
using FinancesLibrary.Events;
using MassTransit;

namespace FinanceController.Domain.Handlers;
public class UserHandler : IHandler<CreateUserCommand>, IHandler<CreateUserFromRouteCommand>
{
    private readonly IUserRepository _userRepository ;
    private readonly IPrivilegeRepository _privilegeRepository ;
    private readonly IMapper _mapper ;
    private readonly ILogger<UserHandler> _logger ;
    private readonly IPublishEndpoint _publishEndpoint ;

    public UserHandler(IUserRepository userRepository, IPrivilegeRepository privilegeRepository, IMapper mapper, ILogger<UserHandler> logger, PublishEndpoint publishEndpoint)
    {
        _userRepository = userRepository;
        _privilegeRepository = privilegeRepository;
        _mapper = mapper;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<ICommandResult> Handle(CreateUserCommand command)
    {
        var user = _mapper.Map<User>(command);
        await _userRepository.CreateUser(user);

        _logger.LogInformation("User from identity server Created successfully");
        return new GenericCommandResult(true, "usuário criado com sucesso", new {});
    }

    public async Task<ICommandResult> Handle(CreateUserFromRouteCommand command)
    {
        var user = _mapper.Map<User>(command);
        foreach (var privilegeId in command.Privileges)
        {
            var privilege = await _privilegeRepository.GetById(privilegeId);
            if (privilege != null)
            {
                user.Privileges.Add(privilege);
            } 
        }

        var createUserEvent = new CreateUserFromRouteEvent
        {
            UserId = user.Id,
            Name = user.Name,
            Email = user.Name,
            Password = command.Password,
        };
        await _userRepository.CreateUser(user);
        await _publishEndpoint.Publish(createUserEvent);
        return new GenericCommandResult(true, "usuário criado com sucesso", user);
    }
}
