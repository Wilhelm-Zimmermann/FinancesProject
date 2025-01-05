using AutoMapper;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Commands.Users;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Handlers.Contracts;
using FinanceController.Domain.Queries.Users;
using FinanceController.Domain.Queries.Users.GetById;
using FinanceController.Domain.Repositories.Contracts;
using FinanceController.Domain.RequestHelpers;
using FinancesLibrary.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FinanceController.Domain.Handlers;
public class UserHandler : IHandler<CreateUserCommand>, IHandler<CreateUserFromRouteCommand>, IHandler<GetMeQuery>
{
    private readonly IUserRepository _userRepository ;
    private readonly IPrivilegeRepository _privilegeRepository ;
    private readonly IMapper _mapper ;
    private readonly ILogger<UserHandler> _logger ;
    private readonly IPublishEndpoint _publishEndpoint ;
    private readonly IUserService _userService;

    public UserHandler(IUserRepository userRepository, IPrivilegeRepository privilegeRepository, IMapper mapper, ILogger<UserHandler> logger, IPublishEndpoint publishEndpoint, IUserService userService)
    {
        _userRepository = userRepository;
        _privilegeRepository = privilegeRepository;
        _mapper = mapper;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
        _userService = userService;
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
        var user = new User(command.Name, command.Email);
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
        return new GenericCommandResult(true, "usuário criado com sucesso", user.Id);
    }

    public async Task<ICommandResult> Handle(GetMeQuery command)
    {
        var user = await _userRepository.GetById(_userService.UserId);

        return new GenericCommandResult(true, "User profile fetched", _mapper.Map<UserDto>(user));
    }
}
