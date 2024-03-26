using FluentAssertions;
using Moq;
using Sportradar.Library.Models;
using Sportradar.Library.Repositories;

namespace Sportradar.Library.Tests;

[TestFixture]
public class ScoreBoardManagerTests
{
    private ScoreBoardManager _sut;
    private Mock<ITeamRepository> _teamRepository;
    private Mock<IFootballMatchRepository> _footballMatchRepository;

    [SetUp]
    public void Setup()
    {
        _teamRepository = new Mock<ITeamRepository>();
        _footballMatchRepository = new Mock<IFootballMatchRepository>();
        
        
        _sut = new ScoreBoardManager(_teamRepository.Object, _footballMatchRepository.Object);
    }

    [Test]
    public void StartNewMatchAsync_ForNotExistingTeams_ShouldCreateThem()
    {
        //arrange
        var notExistingHomeTeamName = "notExistingHomeTeam";
        var notExistingAwayTeamName = "notExistingAwayTeam";
        
        _teamRepository.Setup(x => x.GetTeamAsync(It.IsAny<string>())).ReturnsAsync((Team)null!);

        var createdHomeTeam = new Team(notExistingHomeTeamName);
        var createdAwayTeam = new Team(notExistingAwayTeamName);
        
        _teamRepository.Setup(x => x.CreateTeamAsync(notExistingHomeTeamName)).ReturnsAsync(createdHomeTeam);
        _teamRepository.Setup(x => x.CreateTeamAsync(notExistingAwayTeamName)).ReturnsAsync(createdAwayTeam);
        
        //act
        var result = _sut.StartNewMatchAsync(notExistingHomeTeamName, notExistingAwayTeamName).Result;
        
        //assert
        _teamRepository.Verify(x => x.GetTeamAsync(notExistingHomeTeamName), Times.Once);
        _teamRepository.Verify(x => x.GetTeamAsync(notExistingAwayTeamName), Times.Once);
        
        _teamRepository.Verify(x => x.CreateTeamAsync(notExistingHomeTeamName), Times.Once);
        _teamRepository.Verify(x => x.CreateTeamAsync(notExistingAwayTeamName), Times.Once);
    }

    [Test]
    public void StartNewMatchAsync_ForExistingTeams_ShouldReturnThem()
    {
        //arrange
        var homeTeamName = "HomeTeam";
        var awayTeamName = "AwayTeam";
        
        var homeTeam = new Team(homeTeamName);
        var awayTeam = new Team(awayTeamName);
        
        _teamRepository.Setup(x => x.GetTeamAsync(homeTeamName)).ReturnsAsync(homeTeam);
        _teamRepository.Setup(x => x.GetTeamAsync(awayTeamName)).ReturnsAsync(awayTeam);
        
        //act
        var result = _sut.StartNewMatchAsync(homeTeamName, awayTeamName).Result;
        
        //assert
        _teamRepository.Verify(x => x.GetTeamAsync(homeTeamName), Times.Once);
        _teamRepository.Verify(x => x.GetTeamAsync(awayTeamName), Times.Once);
        
        _teamRepository.Verify(x => x.CreateTeamAsync(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void StartNewMatchAsync_CreatesNewFootbalMatch()
    {
        //arrange
        var homeTeamName = "HomeTeam";
        var awayTeamName = "AwayTeam";
        
        var homeTeam = new Team(homeTeamName);
        var awayTeam = new Team(awayTeamName);
        
        var createdMatch = new FootballMatch(homeTeam, awayTeam);
        
        _teamRepository.Setup(x => x.GetTeamAsync(homeTeamName)).ReturnsAsync(homeTeam);
        _teamRepository.Setup(x => x.GetTeamAsync(awayTeamName)).ReturnsAsync(awayTeam);

        _footballMatchRepository
            .Setup(x => x.CreateFootballMatchAsync(homeTeam, awayTeam))
            .ReturnsAsync(createdMatch);
        
        //act
        var returnedMatch = _sut.StartNewMatchAsync(homeTeamName, awayTeamName).Result;
        
        //assert
        
        _footballMatchRepository.Verify(x => x.CreateFootballMatchAsync(homeTeam, awayTeam), Times.Once);
        
        returnedMatch.Should().Be(createdMatch);
    }
    
    
}