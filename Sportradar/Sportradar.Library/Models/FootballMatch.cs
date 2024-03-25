namespace Sportradar.Library.Models;

public class FootballMatch(Team home, Team away)
{
    public Team Home { get; } = home;
    public Team Away { get; } = away;

    public int HomeScore { get; private set; }
    public int AwayScore { get; private set; }

    // Total score is the sum of home and away scores
    // It is used for sorting matches and increasing performance
    public int TotalScore { get; private set; }
    
    public DateTime StartTime { get; } = DateTime.UtcNow;
    public bool IsFinished { get; set; }

    public void UpdateScore(int homeTeamScore, int awayTeamScore)
    { 
        HomeScore = homeTeamScore;
        AwayScore = awayTeamScore;
        
        TotalScore = HomeScore + AwayScore;
    }
}