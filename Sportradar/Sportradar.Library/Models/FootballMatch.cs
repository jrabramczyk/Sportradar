namespace Sportradar.Library.Models;

public class FootballMatch
{
    public int Id { get; set; }
    
    public Team Home { get; set; }
    public Team Away { get; set; }

    public DateTime StartTime { get; set; }
}