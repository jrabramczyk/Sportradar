using Sportradar.Library.Models;

namespace Sportradar.Library.Repositories;

public static class FakeStorage
{
    public static List<Team> Teams { get; } = new();
    public static List<FootballMatch> FootballMatches { get; } = new();
}