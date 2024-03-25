using Microsoft.Extensions.DependencyInjection;
using Sportradar.Library.Repositories;

namespace Sportradar.Library;

public static class DependencyRegistrar
{
    public static void AddScoreBoardManager(this IServiceCollection services)
    {
        services.AddSingleton<IScoreBoardManager, ScoreBoardManager>();
        
        services.AddSingleton<ITeamRepository, TeamRepository>();
        services.AddSingleton<IFootballMatchRepository, FootballMatchRepository>();
    }
}