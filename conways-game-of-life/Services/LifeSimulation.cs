using conways_game_of_life.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conways_game_of_life.Services
{
    public class LifeSimulation : ILifeSimulation
    {
        private int _width, _height;
        private bool[,] currentGrid, nextGrid;
        private IDisplay _display;

        public LifeSimulation(int height, int width, IDisplay display)
        {
            this._height = height;
            this._width = width;
            _display = display;

            currentGrid = new bool[height, width];
            nextGrid = new bool[height, width];
            GenerateRandomGameField();
        }

        public void DisplayAndSimulate()
        {
            _display.DisplayGame(currentGrid, _height, _width);
            SimulateNextInstance();
        }

        public void GenerateRandomGameField()
        {
            Random rand = new Random();
            for (int y = 0; y < _height; y++)
                for (int x = 0; x < _width; x++)
                    currentGrid[y, x] = rand.NextDouble() < 0.2;
        }

        public int GetAliveNeighbors(int y, int x)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue; // skip self

                    int ny = y + i, nx = x + j;

                    if (IsInBounds(ny, nx) && currentGrid[ny, nx]) NumOfAliveNeighbors++;
                }
            }
            return NumOfAliveNeighbors;
        }

        public bool GetCellValue(int y, int x)
        {
            if (IsInBounds(y, x))
                return currentGrid[y, x];
            return false;
        }

        public void InitializeEmptyGameField()
        {
            for (int y = 0; y < _height; y++)
                for (int x = 0; x < _width; x++)
                    currentGrid[y, x] = false;
        }

        public void SetCellValue(int y, int x, bool state)
        {
            if (IsInBounds(y, x))
                currentGrid[y, x] = state;
        }

        public void SimulateNextInstance()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    int numOfAliveNeighbors = GetAliveNeighbors(y, x);
                    bool isAlive = currentGrid[y, x];

                    //underpopluation-lonelines || overpopulation
                    if (isAlive && (numOfAliveNeighbors < 2 || numOfAliveNeighbors > 3))
                        nextGrid[y, x] = false;
                    else if (!isAlive && numOfAliveNeighbors == 3) //reproduction
                        nextGrid[y, x] = true;
                    else //Survival 
                        nextGrid[y, x] = isAlive;
                }
            }

            // Swap the grids for the next iteration
            var temp = currentGrid;
            currentGrid = nextGrid;
            nextGrid = temp;
        }
        private bool IsInBounds(int y, int x)
        {
            return y >= 0 && y < _height && x >= 0 && x < _width;
        }
    }
}
