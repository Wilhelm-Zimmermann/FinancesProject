namespace FinanceController.Domain.Infra.Jobs;
public interface IJob
{
    void Register();
    Task Execute();
}
