using Sportradar.Library.Models;
using Sportradar.Library.Repositories;

namespace Sportradar.Library;

public interface IScoreBoardManager
{
    Task<FootballMatch> StartNewMatchAsync(string homeTeamName, string awayTeamName);
    Task<FootballMatch> UpdateScoreAsync(string homeTeamName, int homeTeamScore, string awayTeamName,  int awayTeamScore);
    Task<FootballMatch> FinishMatchAsync(string homeTeamName, string awayTeamName);
    Task<IEnumerable<FootballMatch>> GetMatchesAsync();
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

    public async Task<FootballMatch> UpdateScoreAsync(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore)
    {
        var match = await footballMatchRepository.GetFootballMatchAsync(homeTeamName, awayTeamName);

        if (match is null)
        {
            throw new Exception($"Match not found for given teams names {homeTeamName} and {awayTeamName} or match is already finished.");
        }
        
        match.UpdateScore(homeTeamScore, awayTeamScore);
        
        return await footballMatchRepository.UpdateFootballMatchAsync(match);
    }

    public async Task<FootballMatch> FinishMatchAsync(string homeTeamName, string awayTeamName)
    {
        var match = await footballMatchRepository.GetFootballMatchAsync(homeTeamName, awayTeamName);
        
        if (match is null)
        {
            throw new Exception($"Match not found for given teams names {homeTeamName} and {awayTeamName} or match is already finished.");
        }
        
        match.IsFinished = true;
        
        return await footballMatchRepository.UpdateFootballMatchAsync(match);
    }

    public async Task<IEnumerable<FootballMatch>> GetMatchesAsync()
    {
        return await footballMatchRepository.GetFootballMatchesAsync();
    }
    
    private async Task<Team> GetOrCreateTeamAsync(string teamName)
    {
        var team = await teamRepository.GetTeamAsync(teamName) 
                   ?? await teamRepository.CreateTeamAsync(teamName);

        return team;
    }
}