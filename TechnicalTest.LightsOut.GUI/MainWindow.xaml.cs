using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TechnicalTest.LightsOut.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly int Columns = 5;
        private static readonly int Rows = 5;


        private LightGrid _LightGrid;
        private Button[,] _Buttons;

        public MainWindow()
        {
            _LightGrid = new LightGrid(Columns, Rows);
            _Buttons = new Button[Rows, Columns];

            InitializeComponent();

            // Set the grid size so the lights rendering in the correct order
            grid.Columns = Columns;
            grid.Rows = Rows;

            // Loops the lights and attach click handlers
            foreach (var light in _LightGrid.Lights)
            {
                var button = new Button()
                {
                    Background = Brushes.Gray
                };  
                // Apply the event handler and add the light to the grid
                button.Click += new RoutedEventHandler((object sender, RoutedEventArgs e) =>
                {
                    if (_LightGrid.Complete)
                    {
                        return;
                    }

                    _LightGrid.ToggleLight(light.X, light.Y);
                    RedrawGrid();

                    if (_LightGrid.Complete)
                    {
                        MessageBox.Show("You win");
                    }
                });
                _Buttons[light.Y, light.X] = button;
                grid.Children.Add(button);
            }

            // Reset and randomize the grid
            _LightGrid.ResetAndRandomizeStates();
            RedrawGrid();
        }

        private void RedrawGrid()
        {

            foreach (var lightToUpdate in _LightGrid.Lights)
            {
                var buttonToUpdate = _Buttons[lightToUpdate.Y, lightToUpdate.X];
                switch (lightToUpdate.State)
                {
                    case LightState.On:
                        buttonToUpdate.Background = Brushes.Green;
                        break;

                    case LightState.Off:
                        buttonToUpdate.Background = Brushes.Gray;
                        break;
                }
            }
        }
    }
}
