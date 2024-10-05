using FinanceController.Domain.Commands;
using FinanceController.Domain.Handlers;
using FinancesLibrary.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FinanceController.Domain.Infra.Consumers;
public class CreateUserConsumer(UserHandler handler, ILogger<CreateUserConsumer> logger) : IConsumer<CreateUserEvent>
{
    private readonly UserHandler _handler = handler;
    private readonly ILogger<CreateUserConsumer> _logger = logger; 

    public async Task Consume(ConsumeContext<CreateUserEvent> context)
    {
        var userMgs = context.Message;
        var userCommand = new CreateUserCommand((Guid)userMgs.UserId, userMgs.Name, userMgs.Email);

        await _handler.Handle(userCommand);

        _logger.LogInformation($"User {userMgs.UserId} consumed successfully");
    }
}
