﻿namespace FinancesLibrary.Events;
public class CreateUserEvent
{
    public Guid? UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
