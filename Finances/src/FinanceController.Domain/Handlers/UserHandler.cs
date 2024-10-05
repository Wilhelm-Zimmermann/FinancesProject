using AutoMapper;
using FinanceController.Domain.Commands;
using FinanceController.Domain.Commands.Contracts;
using FinanceController.Domain.Entities;
using FinanceController.Domain.Handlers.Contracts;
using FinanceController.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace FinanceController.Domain.Handlers;
public class UserHandler(IUserRepository userRepository, IMapper mapper, ILogger<UserHandler> logger) : IHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<UserHandler> _logger = logger;

    public async Task<ICommandResult> Handle(CreateUserCommand command)
    {
        var user = _mapper.Map<User>(command);
        await _userRepository.CreateUser(user);

        _logger.LogInformation("User Created successfully");
        return new GenericCommandResult(true, "usuário criado com sucesso", new {});
    }
}
