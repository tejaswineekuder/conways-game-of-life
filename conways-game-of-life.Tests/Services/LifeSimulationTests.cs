using conways_game_of_life.Interfaces;
using conways_game_of_life.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conways_game_of_life.Tests.Services
{
    public class LifeSimulationTests
    {
        private Mock<IDisplay> _mockConsoleDisplay;

        public LifeSimulationTests()
        {
            // Initialize the test environment if needed
            _mockConsoleDisplay = new Mock<IDisplay>();
        }

        [Test]
        public void Update_Blinker_Oscillates()
        {
            // Arrange
            _mockConsoleDisplay.Setup(x => x.DisplayGame(It.IsAny<bool[,]>(), It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            var grid = new LifeSimulation(5, 5, _mockConsoleDisplay.Object);

            grid.InitializeEmptyGameField();

            // Set up a vertical line
            grid.SetCellValue(2, 1, true);
            grid.SetCellValue(2, 2, true);
            grid.SetCellValue(2, 3, true);

            grid.SimulateNextInstance();


            // After 1 update, it should become horizontal
            Assert.False(grid.GetCellValue(2, 1));
            Assert.True(grid.GetCellValue(1, 2));
            Assert.True(grid.GetCellValue(2, 2));
            Assert.True(grid.GetCellValue(3, 2));
            Assert.False(grid.GetCellValue(2, 3));
        }

        [Test]
        public void Update_Block_RemainsStable()
        {
            // Arrange
            _mockConsoleDisplay.Setup(x => x.DisplayGame(It.IsAny<bool[,]>(), It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            var grid = new LifeSimulation(5, 5, _mockConsoleDisplay.Object);

            grid.InitializeEmptyGameField();

            // Block: still life
            grid.SetCellValue(1, 1, true);
            grid.SetCellValue(1, 2, true);
            grid.SetCellValue(2, 1, true);
            grid.SetCellValue(2, 2, true);

            //var before = CloneGrid(grid);

            //grid.Update();

            //Assert.True(AreGridsEqual(before, grid));
        }

        [Test]
        public void Update_LonelyCell_Dies()
        {
            // Arrange
            _mockConsoleDisplay.Setup(x => x.DisplayGame(It.IsAny<bool[,]>(), It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            var grid = new LifeSimulation(5, 5, _mockConsoleDisplay.Object);

            grid.InitializeEmptyGameField();

            grid.SetCellValue(1, 1, true); // one lonely cell
            grid.SimulateNextInstance();

            Assert.False(grid.GetCellValue(1, 1)); // dies of underpopulation
        }

    }
}
