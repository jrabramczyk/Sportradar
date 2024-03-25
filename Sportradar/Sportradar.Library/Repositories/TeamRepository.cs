using Sportradar.Library.Models;

namespace Sportradar.Library.Repositories;

public interface ITeamRepository
{
    Task<Team?>? GetTeamAsync(string teamName);
    Task<Team> CreateTeamAsync(string teamName);
}

public class TeamRepository : ITeamRepository
{
    public Task<Team?> GetTeamAsync(string teamName)
    {
        return Task.FromResult(TeamStore.Teams.FirstOrDefault(t => t.Name == teamName));
    }

    public Task<Team> CreateTeamAsync(string teamName)
    {
        if (TeamStore.Teams.Any(t => t.Name == teamName))
        {
            throw new InvalidOperationException($"Team with name {teamName} already exists.");
        }
        else
        {
            var team = new Team(teamName);
            TeamStore.Teams.Add(team);  
            
            return Task.FromResult(team);
        }
    }
}

public static class TeamStore
{
    public static List<Team> Teams { get; } = new();
}