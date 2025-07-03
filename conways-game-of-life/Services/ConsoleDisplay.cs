using conways_game_of_life.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conways_game_of_life.Services
{
    public class ConsoleDisplay : IDisplay
    {
        public void DisplayGame(bool[,] grid, int height, int width)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(grid[y, x] ? "0" : ".");
                    if (x == width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }
    }
}

