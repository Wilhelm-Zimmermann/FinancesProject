using Microsoft.AspNetCore.Authorization;

namespace FinanceController.Domain.Api.Authentication;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string? Privilege { get; private set; }

    public PermissionRequirement(string? privilege)
    {
        Privilege = privilege;
    }
}
