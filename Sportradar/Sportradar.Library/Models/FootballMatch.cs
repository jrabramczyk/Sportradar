namespace Sportradar.Library.Models;

public class FootballMatch(Team home, Team away)
{
    public Team Home { get; } = home;
    public Team Away { get; } = away;

    public DateTime StartTime { get; } = DateTime.UtcNow;
    public bool IsFinished { get; set; } = false;
}