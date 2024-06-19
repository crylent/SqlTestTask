using System.Collections.Specialized;
using System.Configuration;

namespace SqlTestTask.Services;

public class DbConfigService: IDbConfigService
{
    private readonly NameValueCollection _config = ConfigurationManager.AppSettings;

    public string? GetHost() => _config["host"];
    public string? GetInstance() => _config["instance"];
    public string? GetPort() => _config["port"];
    public string? GetDatabase() => _config["database"];
}