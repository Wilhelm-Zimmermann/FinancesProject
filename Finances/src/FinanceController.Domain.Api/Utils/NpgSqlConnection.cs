using Hangfire.PostgreSql;
using Npgsql;

namespace FinanceController.Domain.Api.Utils;

public class NpgSqlConnection : IConnectionFactory
{
    public NpgsqlConnection GetOrCreateConnection()
    {
        return new NpgsqlConnection("Server=localhost:5432;User Id=postgres;Password=1234;Database=identity");
    }
}
