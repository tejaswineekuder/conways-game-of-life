using conways_game_of_life.Interfaces;
using conways_game_of_life.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



// Initialising some custom values for the game to run.
var Height = 5;
var Width = 5;
var MaxRuns = 50;
var runs = 0;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<IDisplay, ConsoleDisplay>();
        services.AddSingleton<ILifeSimulation, LifeSimulation>(provider =>
        {
            var displayService = provider.GetRequiredService<IDisplay>();
            return new LifeSimulation(Height, Width, displayService);
        });
    })
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

var displayService = services.GetRequiredService<IDisplay>();
var lifeSimulationService = services.GetRequiredService<ILifeSimulation>();

lifeSimulationService = new LifeSimulation(Height, Width, displayService);


while (runs++ < MaxRuns)
{
    lifeSimulationService.DisplayAndSimulate();

    // Give the user a chance to view the game in a more reasonable speed.
    System.Threading.Thread.Sleep(400);
}