using Sportradar.Library;

namespace Sportradar.ConsoleApp;

public class CommandHandler
{
    public static void FinishMatchCommand(string[] command, IScoreBoardManager scoreBoardManager)
    {
        try
        {
            var homeTeamName = command[2];
            var awayTeamName = command[4];
                    
            scoreBoardManager.FinishMatchAsync(homeTeamName, awayTeamName).Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Invalid command for finish match, exception: {e.Message}");
        }
        
    }

    public static void UpdateMatchCommand(string[] command, IScoreBoardManager scoreBoardManager)
    {
        try
        {
            var homeTeamName = command[2];
            var homeTeamScore = int.Parse(command[3]);
            var awayTeamName = command[5];
            var awayTeamScore = int.Parse(command[6]);
                    
            scoreBoardManager.UpdateScoreAsync(homeTeamName, homeTeamScore, awayTeamName, awayTeamScore).Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Invalid command for update match, exception: {e.Message}");
        }
        
    }

    public static void StartMatchCommand(string[] command, IScoreBoardManager scoreBoardManager)
    {
        try
        {
            var homeTeamName = command[2];
            var awayTeamName = command[4];

            scoreBoardManager.StartNewMatchAsync(homeTeamName, awayTeamName).Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Invalid command for start match, exception: {e.Message}");
        }
    }
}