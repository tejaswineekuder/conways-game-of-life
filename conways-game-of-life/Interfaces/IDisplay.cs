using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conways_game_of_life.Interfaces
{
    public interface IDisplay
    {
        /// <summary>
        /// Draws the game.
        /// </summary>
        void DisplayGame(bool[,] grid, int height, int width);
    }
}
