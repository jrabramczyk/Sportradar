namespace Sportradar.Library.Models;

public class Team(string name)
{
    // Name is also used as the key
    public string Name { get; } = name;
}