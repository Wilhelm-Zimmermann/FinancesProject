namespace FinancesLibrary.Events;

public class CreateUserFromRouteEvent
{
    public Guid? UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}