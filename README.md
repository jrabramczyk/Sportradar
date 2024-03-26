# Sportradar

## Running the project

Mark the project **Sportradar.ConsoleApp** as the startup project and run it. The console application will start and you will be able to interact with it by typing commands.

## Reusing library in other projects

The library **Sportradar.Library** can be reused in other projects. It is a .NET Standard 2.0 library, so it can be used in .NET Core and .NET Framework projects.

Simply in the dependency injection framework in your project, register the service. 
The library has a `DependencyRegistrar` class that has an extension method `AddScoreBoardManager` that can be used to register the service.
    
Usage example you can find in the **Sportradar.ConsoleApp** project in the `DependencyRegistrar.cs` file.

``` 
services.AddScoreBoardManager();
```


## Running tests

All tests are in the **Sportradar.Library.Tests** project. 

If you want to run example test from the exercise, simply add the following code to the `Program.cs` file:

```
scoreBoardManager.StartNewMatchAsync("Mexico", "Canada").Wait();
scoreBoardManager.StartNewMatchAsync("Spain", "Brazil").Wait();
scoreBoardManager.StartNewMatchAsync("Germany", "France").Wait();
scoreBoardManager.StartNewMatchAsync("Uruguay", "Italy").Wait();
scoreBoardManager.StartNewMatchAsync("Argentina", "Australia").Wait();

scoreBoardManager.UpdateScoreAsync("Mexico", 0, "Canada", 5).Wait();
scoreBoardManager.UpdateScoreAsync("Spain", 10,"Brazil", 2).Wait();
scoreBoardManager.UpdateScoreAsync("Germany", 2, "France", 2).Wait();
scoreBoardManager.UpdateScoreAsync("Uruguay", 6, "Italy", 6).Wait();
scoreBoardManager.UpdateScoreAsync("Argentina", 3, "Australia", 1).Wait();
```
