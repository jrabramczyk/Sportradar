using Microsoft.Extensions.DependencyInjection;
using Sportradar.Library;

namespace Sportradar.ConsoleApp;

public static class DependencyRegistrar
{
    public static ServiceProvider RegisterDependencies()
    {
        var services = new ServiceCollection();
            
        services.AddScoreBoardManager();
            
        return services.BuildServiceProvider();
    }
}