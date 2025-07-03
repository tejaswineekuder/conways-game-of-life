using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conways_game_of_life.Interfaces
{
    public interface ILifeSimulation
    {
        /// <summary>
        /// Advances the game by one generation and prints the current state to console.
        /// </summary>

        public void DisplayAndSimulate();

        /// <summary>
        /// Advances the game by one generation according to GoL's ruleset.
        /// </summary>
        public void SimulateNextInstance();

        /// <summary>
        /// Checks how many alive neighbors are in the vicinity of a cell.
        /// </summary>
        /// <param name="x">X-coordinate of the cell.</param>
        /// <param name="y">Y-coordinate of the cell.</param>
        /// <returns>The number of alive neighbors.</returns>
        public int GetAliveNeighbors(int y, int x);

        /// <summary>
        /// Initializes the field with random boolean values.
        /// </summary>
        public void GenerateRandomGameField();

        /// <summary>
        /// Initializes the field by setting all values to false.
        /// </summary>
        public void InitializeEmptyGameField();

        /// <summary>
        /// Sets the field value to true.
        /// </summary>
        public void SetCellValue(int y, int x, bool state);

        /// <summary>
        /// Gets the field value.
        /// </summary>
        public bool GetCellValue(int y, int x);
    }
}
