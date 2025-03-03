using Hangfire.PostgreSql;
using Npgsql;

namespace FinanceController.Domain.Api.Utils;

public class NpgSqlConnection : IConnectionFactory
{
    private readonly string _connectionString;

    public NpgSqlConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public NpgsqlConnection GetOrCreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
