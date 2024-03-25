using Sportradar.Library.Models;
using Sportradar.Library.Repositories;

namespace Sportradar.Library;

public interface IScoreBoardManager
{
    Task<FootballMatch> StartNewMatchAsync(string homeTeamName, string awayTeamName);
    Task<FootballMatch> UpdateScoreAsync(string homeTeamName, int homeTeamScore, string awayTeamName,  int awayTeamScore);
    Task FinishMatchAsync(string homeTeamName, string awayTeamName);
    Task<List<FootballMatch>> GetMatchesAsync();
}

public class ScoreBoardManager(ITeamRepository teamRepository, IFootballMatchRepository footballMatchRepository) : IScoreBoardManager
{
    public async Task<FootballMatch> StartNewMatchAsync(string homeTeamName, string awayTeamName)
    {
        var homeTeam = await GetOrCreateTeamAsync(homeTeamName);
        var awayTeam = await GetOrCreateTeamAsync(awayTeamName);

        var match = await footballMatchRepository.CreateFootballMatchAsync(homeTeam, awayTeam);

        return match;
    }

    public Task<FootballMatch> UpdateScoreAsync(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore)
    {
        throw new NotImplementedException();
    }

    public Task FinishMatchAsync(string homeTeamName, string awayTeamName)
    {
        throw new NotImplementedException();
    }

    public Task<List<FootballMatch>> GetMatchesAsync()
    {
        throw new NotImplementedException();
    }
    
    private async Task<Team> GetOrCreateTeamAsync(string teamName)
    {
        var team = await teamRepository.GetTeamAsync(teamName) 
                   ?? await teamRepository.CreateTeamAsync(teamName);

        return team;
    }
}