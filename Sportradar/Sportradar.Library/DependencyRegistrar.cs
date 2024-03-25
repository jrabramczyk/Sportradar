using Microsoft.Extensions.DependencyInjection;

namespace Sportradar.Library;

public static class DependencyRegistrar
{
    public static void AddScoreBoardManager(this IServiceCollection services)
    {
        services.AddSingleton<IScoreBoardManager, ScoreBoardManager>();
    }
}