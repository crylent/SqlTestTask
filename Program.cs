using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using SqlTestTask.Forms;
using SqlTestTask.Services;

namespace SqlTestTask;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var host = CreateHost();
        var serviceProvider = host.Services;
        
        ApplicationConfiguration.Initialize();
        Application.Run(serviceProvider.GetRequiredService<StaffViewer>());
    }

    private static IHost CreateHost()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((_, services)=>{
                services.AddSingleton<IDatabaseService, DatabaseService>();
                services.AddSingleton<IDbConfigService, DbConfigService>();
                services.AddSingleton<ICatalogService, CatalogService>();
                
                services.AddTransient<DbConnectionForm>();
                services.AddTransient<StaffViewer>();
                services.AddTransient<DateRangeForm>();
            })
            .ConfigureLogging(builder => builder.AddConsole())
            .Build();
    }

}