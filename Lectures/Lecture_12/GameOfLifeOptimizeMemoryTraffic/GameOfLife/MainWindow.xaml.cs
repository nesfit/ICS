using System;
using System.Windows;

namespace GameOfLife
{
    public partial class MainWindow : Window
    {
        private Grid mainGrid;
        System.Windows.Threading.DispatcherTimer timer;
        private int genCounter;

        public MainWindow()
        {
            InitializeComponent();
            mainGrid = new Grid(MainCanvas);
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += OnTimer;
            timer.Interval = TimeSpan.FromMilliseconds(200);
        }

        private void Button_OnClick(object sender, EventArgs e)
        {
            if (!timer.IsEnabled)
            {
                timer.Start();
                ButtonStart.Content = "Stop";
            }
            else
            {
                timer.Stop();
                ButtonStart.Content = "Start";
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            mainGrid.Update();
            genCounter++;
            lblGenCount.Content = "Generations: " + genCounter;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Clear();
        }
    }
}
