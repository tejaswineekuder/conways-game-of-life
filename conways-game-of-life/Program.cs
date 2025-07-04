﻿using conways_game_of_life.Interfaces;
using conways_game_of_life.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



// Initialising some custom values for the game to run.
var Height = 10;
var Width = 40;
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


var lifeSimulationService = host.Services.GetRequiredService<ILifeSimulation>();


while (runs++ < MaxRuns)
{
    lifeSimulationService.DisplayAndSimulate();

    // Give the user a chance to view the game in a more reasonable speed.
    System.Threading.Thread.Sleep(400);
}