namespace FinanceController.Domain.Api.Authentication;

public interface IPermissionService
{
    Task<bool> IsAuthorize(Guid userId, string privilege);
}
