using Sportradar.Library.Models;

namespace Sportradar.Library.Repositories;

public interface IFootballMatchRepository
{
    Task<FootballMatch?> GetFootballMatchAsync(string homeTeamName, string awayTeamName);
    Task<IEnumerable<FootballMatch>> GetFootballMatchesAsync();
    Task<FootballMatch> CreateFootballMatchAsync(Team home, Team away);
    Task<FootballMatch> UpdateFootballMatchAsync(FootballMatch match);
}

public class FootballMatchRepository : IFootballMatchRepository
{
    public Task<FootballMatch?> GetFootballMatchAsync(string homeTeamName, string awayTeamName)
    {
        return Task.FromResult(FakeStorage.FootballMatches.FirstOrDefault(x =>
            x.Home.Name == homeTeamName && x.Away.Name == awayTeamName));
    }

    public Task<IEnumerable<FootballMatch>> GetFootballMatchesAsync()
    {
        return Task.FromResult<IEnumerable<FootballMatch>>(FakeStorage.FootballMatches.ToList());
    }

    public Task<FootballMatch> CreateFootballMatchAsync(Team home, Team away)
    {
        if(FakeStorage.FootballMatches.Any(m => m.Home.Name == home.Name 
                                                && m.Away.Name == away.Name 
                                                && !m.IsFinished))
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

    public Task<FootballMatch> UpdateFootballMatchAsync(FootballMatch match)
    {
        var storageMatch = FakeStorage.FootballMatches.FirstOrDefault(m => m.Home.Name == match.Home.Name
                                                                           && m.Away.Name == match.Away.Name
                                                                           && !m.IsFinished);
        
        if (storageMatch is null)
        {
            throw new InvalidOperationException($"Match between {match.Home.Name} and {match.Away.Name} not found.");
        }
        else
        {
            FakeStorage.FootballMatches.Remove(storageMatch);
            FakeStorage.FootballMatches.Add(match);
            
            return Task.FromResult(match);
        }
    }
}