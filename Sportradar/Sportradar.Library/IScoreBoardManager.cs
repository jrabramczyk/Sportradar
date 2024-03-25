using Sportradar.Library.Models;

namespace Sportradar.Library;

public interface IScoreBoardManager
{
    Task<FootballMatch> StartNewMatchAsync(string homeTeamName, string awayTeamName);
    Task<FootballMatch> UpdateScoreAsync(int matchId, int homeTeamScore, int awayTeamScore);
    Task FinishMatchAsync(int matchId);
    Task<List<FootballMatch>> GetMatchesAsync();
}