using Sportradar.Library.Models;

namespace Sportradar.Library.Repositories;

public interface ITeamRepository
{
    Task<Team?> GetTeamAsync(string teamName);
    Task<Team> CreateTeamAsync(string teamName);
}

public class TeamRepository : ITeamRepository
{
    public Task<Team?> GetTeamAsync(string teamName)
    {
        return Task.FromResult(TeamStorage.Teams.FirstOrDefault(t => t.Name == teamName));
    }

    public Task<Team> CreateTeamAsync(string teamName)
    {
        if (TeamStorage.Teams.Any(t => t.Name == teamName))
        {
            throw new InvalidOperationException($"Team with name {teamName} already exists.");
        }
        else
        {
            var team = new Team(teamName);
            TeamStorage.Teams.Add(team);  
            
            return Task.FromResult(team);
        }
    }
}

