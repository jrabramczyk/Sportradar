using FluentAssertions;
using Sportradar.Library.Models;
using Sportradar.Library.Repositories;

namespace Sportradar.Library.Tests;

[TestFixture]
public class FootballMatchRepositoryTests
{
    private FootballMatchRepository _footbalMatchRepository;

    [SetUp]
    public void Setup()
    {
        FakeStorage.Teams.Clear();
        FakeStorage.FootballMatches.Clear();

        _footbalMatchRepository = new FootballMatchRepository();
    }

    [Test]
    public void CreateFootballMatchAsync_CreateMatchWhenNotExist()
    {
        //arrange
        var homeTeam = new Team("HomeTeam");
        var awayTeam = new Team("AwayTeam");

        //act
        var expectignMatch = _footbalMatchRepository.CreateFootballMatchAsync(homeTeam, awayTeam).Result;

        //assert
        FakeStorage.FootballMatches.Count.Should().Be(1);
        FakeStorage.FootballMatches.Should().Contain(expectignMatch);
    }

    [Test]
    public void CreateFootballMatchAsync_ThrowExceptionWhenMatchAlreadyExist()
    {
        //arrange
        var homeTeam = new Team("HomeTeam");
        var awayTeam = new Team("AwayTeam");

        _footbalMatchRepository.CreateFootballMatchAsync(homeTeam, awayTeam).Wait();

        //act
        Action act = () => _footbalMatchRepository.CreateFootballMatchAsync(homeTeam, awayTeam).Wait();

        //assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Match between HomeTeam and AwayTeam already exists.");
    }
    
    [Test]
    public void CreateFootballMatchAsync_CreatesMatchWhenExistsButFinished()
    {
        //arrange
        var homeTeam = new Team("HomeTeam");
        var awayTeam = new Team("AwayTeam");

        var match = new FootballMatch(homeTeam, awayTeam)
        {
            IsFinished = true
        };
        
        FakeStorage.FootballMatches.Add(match);

        //act
        var expectignMatch = _footbalMatchRepository.CreateFootballMatchAsync(homeTeam, awayTeam).Result;

        //assert
        FakeStorage.FootballMatches.Count.Should().Be(2);
        FakeStorage.FootballMatches.Should().Contain(expectignMatch);
    }
}