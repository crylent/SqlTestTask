namespace SqlTestTask.Services;

public interface IDbConfigService
{
    protected string? GetHost();
    protected string? GetInstance();
    protected string? GetPort();
    protected string? GetDatabase();

    public string GetConnectionString(bool integratedSecurity = true) =>
        $"Server={GetHost()}\\{GetInstance()},{GetPort()};" +
        $"Database={GetDatabase()};" +
        $"Integrated Security={integratedSecurity};" +
        $"TrustServerCertificate=yes";
}