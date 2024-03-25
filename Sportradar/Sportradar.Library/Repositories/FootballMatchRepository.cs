using Sportradar.Library.Models;

namespace Sportradar.Library.Repositories;

public interface IFootballMatchRepository
{
    Task<IEnumerable<FootballMatch>> GetFootballMatchesAsync();
    Task<FootballMatch> CreateFootballMatchAsync(Team home, Team away);
}

public class FootballMatchRepository : IFootballMatchRepository
{
    public Task<IEnumerable<FootballMatch>> GetFootballMatchesAsync()
    {
        return Task.FromResult<IEnumerable<FootballMatch>>(FakeStorage.FootballMatches.ToList());
    }

    public Task<FootballMatch> CreateFootballMatchAsync(Team home, Team away)
    {
        if(FakeStorage.FootballMatches.Any(m => m.Home.Name == home.Name && m.Away.Name == away.Name && !m.IsFinished))
        {
            throw new InvalidOperationException($"Match between {home.Name} and {away.Name} already exists.");
        }
        else
        {
            var match = new FootballMatch(home, away);
            FakeStorage.FootballMatches.Add(match);
            
            return Task.FromResult(match);
        }
    }
}