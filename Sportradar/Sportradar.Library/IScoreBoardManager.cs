using Sportradar.Library.Models;
using Sportradar.Library.Repositories;

namespace Sportradar.Library;

public interface IScoreBoardManager
{
    Task<FootballMatch> StartNewMatchAsync(string homeTeamName, string awayTeamName);
    Task<FootballMatch> UpdateScoreAsync(int matchId, int homeTeamScore, int awayTeamScore);
    Task FinishMatchAsync(int matchId);
    Task<List<FootballMatch>> GetMatchesAsync();
}

public class ScoreBoardManager(ITeamRepository teamRepository) : IScoreBoardManager
{
    private readonly ITeamRepository _teamRepository = teamRepository;

    public async Task<FootballMatch> StartNewMatchAsync(string homeTeamName, string awayTeamName)
    {
        var homeTeam = await GetOrCreateTeamAsync(homeTeamName);
        var awayTeam = await GetOrCreateTeamAsync(awayTeamName);
        
        var match = new FootballMatch
        {
            Home = homeTeam,
            Away = awayTeam,
            StartTime = DateTime.UtcNow
        };

        throw new NotImplementedException();
    }

    

    public Task<FootballMatch> UpdateScoreAsync(int matchId, int homeTeamScore, int awayTeamScore)
    {
        throw new NotImplementedException();
    }

    public Task FinishMatchAsync(int matchId)
    {
        throw new NotImplementedException();
    }

    public Task<List<FootballMatch>> GetMatchesAsync()
    {
        throw new NotImplementedException();
    }
    
    private async Task<Team> GetOrCreateTeamAsync(string teamName)
    {
        var team = await _teamRepository.GetTeamAsync(teamName) 
                   ?? await _teamRepository.CreateTeamAsync(teamName);

        return team;
    }
}