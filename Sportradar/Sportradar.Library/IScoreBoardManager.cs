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

    public Task<FootballMatch> StartNewMatchAsync(string homeTeamName, string awayTeamName)
    {
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
}