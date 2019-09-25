using Xunit;

namespace TechnicalTest.LightsOut.Tests
{
    public class LightGridTests
    {
        [Theory]
        [InlineData(3, 3, 9)]
        [InlineData(1, 3, 3)]
        [InlineData(1, 1, 1)]
        public void CreateGridColumnsAndRows(int columns, int rows, int expected)
        {
            var grid = new LightGrid(columns, rows);

            Assert.Equal(expected, grid.Lights.Length);

        }

        [Fact]
        public void CreateGridColumnsAndRowsAndTurnOnCenter()
        {

            int x = 2;
            int y = 2;
            var grid = new LightGrid(5, 5);

            var centerLight = grid.GetLight(x, y);

            grid.ToggleLight(x, y);

            Assert.Equal(LightState.On, centerLight.State);

        }

        [Theory]
        [InlineData(5, 5, 2, 2, 5)]
        [InlineData(2, 2, 0, 0, 3)]
        public void CreateGridColumnsAndRowsAndTurnOnCenterCheckLightsOn(int columns, int rows, int x, int y, int expected)
        {

            var grid = new LightGrid(columns, rows);

            grid.ToggleLight(x, y);

            var lightsOn = grid.GetLights(LightState.On);

            Assert.Equal(expected, lightsOn.Count);

        }
    }
}
