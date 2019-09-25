
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechnicalTest.LightsOut
{
    public class LightGrid
    {

        public readonly int Columns, Rows;
        // All the lights contained in the grid
        public Light[,] Lights;
        public bool Complete { get; private set; } = false;

        public LightGrid(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            Lights = new Light[rows, columns];
            // Reset the grid to ensure the array does not contain nulls 
            // and the state of each light is off
            Reset();
        }

        /**
         * Gets the light for the requested row and column
         */
        public Light GetLight(int x, int y)
        {
            // Check to ensure the requested light is within the contains 
            // of the defined dimensions, returning null if it isnt
            if (x < 0 || Columns <= x || y < 0 || Rows <= y)
            {
                return null;
            }

            return Lights[y, x];
        }

        /**
         * Resets the grid to the initial state of all lights being off
         */
        public void Reset()
        {
            for(var x = 0; x < Columns; x++)
            {
                for(var y = 0; y < Rows; y++)
                {
                    // if the light are this position is null, create a new light
                    if (Lights[y, x] == null)
                    {
                        Lights[y, x] = new Light(x, y);
                    }

                    // Reset the light to defaults
                    Lights[y, x].Reset();
                }
            }
        }

        /**
         * Resets the grid and
         * randomizes the states of all the lights
         */
        public void ResetAndRandomizeStates()
        {
            Reset();
            var random = new Random();
            foreach (var light in Lights)
            {

                // Randomly turn light on
                if (random.Next(Lights.Length) == 1)
                {
                    light.Toggle();
                }
            }
        }

        /**
         * Handles clicking the light as well as
         * toggling other lights in the surround area
         */
        public void ToggleLight(int x, int y)
        {
            // Get the light object for the coord reference
            var light = GetLight(x, y);

            if (light == null)
            {
                throw new ArgumentNullException();
            }

            // Toggle the clicked light
            light.Toggle();

            // Grab the lights for the surrounding area
            List<Light> surroundingLights = new List<Light>()
            {
                GetLight(light.X - 1, light.Y), // Left
                GetLight(light.X + 1, light.Y), // Right
                GetLight(light.X, light.Y - 1), // Top
                GetLight(light.X, light.Y + 1)  // Bottom
            };

            // Loop the lights and toggle them
            foreach (var surroundingLight in surroundingLights)
            {
                if (surroundingLight != null)
                {
                    surroundingLight.Toggle();
                }
            }

            // Check if all the lights are turned off
            // Display a you win message if they've won
            if (!Complete && GetLights(LightState.Off).Count == Lights.Length)
            {
                Complete = true;
            }
        }

        /**
         * Gets all the lights in the requested state
         */
        public List<Light> GetLights(LightState state)
        {
            List<Light> lightsInState = new List<Light>();
            foreach (var light in Lights)
            {
                if (light.State == state)
                {
                    lightsInState.Add(light);
                }
            }

            return lightsInState;
        }
    }
}
