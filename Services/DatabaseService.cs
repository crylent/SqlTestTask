using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SqlTestTask.Enums;

namespace SqlTestTask.Services;

public class DatabaseService(ILogger<DatabaseService> logger, IDbConfigService config): IDatabaseService
{
    private SqlConnection? _connection;

    public string? Error { get; private set; }

    public async Task<bool> Connect(SqlCredential? credential)
    {
        var connectionString = config.GetConnectionString(credential is null);
        logger.LogInformation("{ConnectionString}", connectionString);
        try
        {
            _connection = new SqlConnection(connectionString, credential);
            await _connection.OpenAsync();
        }
        catch (SqlException e)
        {
            Error = e.Message;
            logger.LogInformation("Connection failed: {Error}", Error);
            return false;
        }
        logger.LogInformation("Connection status: {State}", _connection?.State);
        return _connection?.State == ConnectionState.Open;
    }

    public async Task<DataTable> SelectTable(StoredProcedure procedure, SqlParameter[]? parameters = null)
    {
        await using var cmd = CreateCommand(procedure, parameters);
        var table = new DataTable();
        table.Load(await cmd.ExecuteReaderAsync());
        return table;
    }

    public async Task<T?> SelectValue<T>(StoredProcedure procedure, SqlParameter[]? parameters = null)
    {
        await using var cmd = CreateCommand(procedure, parameters);
        return (T?) await cmd.ExecuteScalarAsync();
    }

    public async Task<SqlException?> TestConnection()
    {
        try
        {
            await using var cmd = CreateCommand(StoredProcedure.GetTotalEmployees);
            await cmd.ExecuteScalarAsync();
            return null;
        }
        catch (SqlException e)
        {
            return e;
        }
    }

    private SqlCommand CreateCommand(StoredProcedure procedure, SqlParameter[]? parameters = null)
    {
        var cmd = new SqlCommand();
        cmd.CommandText = procedure.ToString();
        if (parameters is not null) cmd.Parameters.AddRange(parameters);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = _connection;
        return cmd;
    }
}