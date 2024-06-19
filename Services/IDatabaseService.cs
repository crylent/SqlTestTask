using System.Data;
using Microsoft.Data.SqlClient;
using SqlTestTask.Enums;

namespace SqlTestTask.Services;

public interface IDatabaseService
{
    public Task<bool> Connect(SqlCredential? credential = null);
    public Task<DataTable> SelectTable(StoredProcedure procedure, SqlParameter[]? parameters = null);
    public Task<T?> SelectValue<T>(StoredProcedure procedure, SqlParameter[]? parameters = null);
    public Task<SqlException?> TestConnection();
    
    public string? Error { get; }
}