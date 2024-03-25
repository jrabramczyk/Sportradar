// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Sportradar.Library;

namespace Sportradar.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var services = RegisterDependencies();
            
            Console.WriteLine("Scoreboard Manager is ready to use.");
        }

        private static ServiceProvider RegisterDependencies()
        {
            var services = new ServiceCollection();
            
            services.AddScoreBoardManager();
            
            return services.BuildServiceProvider();
        }
    }
}