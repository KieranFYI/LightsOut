using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TechnicalTest.LightsOut.Tests
{
    public class LightTest
    {
        [Fact]
        public void ToggleLightOn()
        {
            var expected = LightState.On;

            var light = new Light(0, 0);
            light.Reset();

            light.Toggle();

            Assert.Equal(expected, light.State);
        }
    }
}
