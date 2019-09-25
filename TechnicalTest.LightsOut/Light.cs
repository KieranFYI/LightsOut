
using System.Windows.Controls;
using System.Windows.Media;

namespace TechnicalTest.LightsOut
{
    public class Light
    {
        public readonly int X, Y;
        // The current state of the light, default to off
        public LightState State { get; private set; } = LightState.Off;

        public Light(int x, int y)
        {
            X = x;
            Y = y;
        }

        /**
         * Allows quick toggling of the light on and off
         */
        public void Toggle()
        {
            State = State.Equals(LightState.Off) ? LightState.On : LightState.Off;
        }

        /**
         * Reset the light to the default state
         */
        public void Reset()
        {
            State = LightState.Off;
        }

    }
}
