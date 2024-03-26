using Sportradar.Library;

namespace Sportradar.ConsoleApp;

public class CommandHandler
{
    public static void FinishMatchCommand(string[] command, IScoreBoardManager scoreBoardManager)
    {
        var homeTeamName = command[2];
        var awayTeamName = command[4];
                    
        scoreBoardManager.FinishMatchAsync(homeTeamName, awayTeamName).Wait();
    }

    public static void UpdateMatchCommand(string[] command, IScoreBoardManager scoreBoardManager)
    {
        var homeTeamName = command[2];
        var homeTeamScore = int.Parse(command[3]);
        var awayTeamName = command[5];
        var awayTeamScore = int.Parse(command[6]);
                    
        scoreBoardManager.UpdateScoreAsync(homeTeamName, homeTeamScore, awayTeamName, awayTeamScore).Wait();
    }

    public static void StartMatchCommand(string[] command, IScoreBoardManager scoreBoardManager)
    {
        var homeTeamName = command[2];
        var awayTeamName = command[4];
                    
        scoreBoardManager.StartNewMatchAsync(homeTeamName, awayTeamName).Wait();
    }
}