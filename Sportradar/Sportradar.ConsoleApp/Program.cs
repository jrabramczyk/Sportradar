// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Sportradar.Library;

namespace Sportradar.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var services = DependencyRegistrar.RegisterDependencies();
            
            var scoreBoardManager = services.GetRequiredService<IScoreBoardManager>();
           
            Console.WriteLine("Please select on of the following options:"
                              + "\n1. Start new match, type: 'start -h <home_team_name> -a <away_team_name>'"
                              + "\n2. Update score, type: 'update -h <home_team_name> <home_team_score> -a <away_team_name> <away_team_score>'"
                              + "\n3. Finish match, type: 'finish -h <home_team_name> -a <away_team_name>'"
                              + "\n4. Get matches, type: 'get-matches'"
                              + "\n5. Exit");
            
            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                
                if (command[0] == "start")
                {
                    CommandHandler.StartMatchCommand(command, scoreBoardManager);
                }
                else if (command[0] == "update")
                {
                    CommandHandler.UpdateMatchCommand(command, scoreBoardManager);
                }
                else if (command[0] == "finish")
                {
                    CommandHandler.FinishMatchCommand(command, scoreBoardManager);
                }
                else if (command[0] == "get-matches")
                {
                    var matches = scoreBoardManager.GetMatchesAsync().Result;
                    
                    foreach (var match in matches.OrderByDescending(x => x.TotalScore).ThenByDescending(x => x.StartTime))
                    {
                        Console.WriteLine($"{match.Home.Name} {match.HomeScore} - {match.AwayScore} {match.Away.Name}");
                    }
                }
                else if (command[0] == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command, please try again.");
                }
            }
        }
    }
}