namespace Sportradar.Library.Models;

public class FootballMatch(Team home, Team away)
{
    public Team Home { get; } = home;
    public Team Away { get; } = away;

    public int HomeScore { get; set; } = 0;
    public int AwayScore { get; set; } = 0;
    

    public DateTime StartTime { get; } = DateTime.UtcNow;
    public bool IsFinished { get; set; } = false;

    public void UpdateScore(int homeTeamScore, int awayTeamScore)
    { 
        HomeScore = homeTeamScore;
        AwayScore = awayTeamScore;
    }
}