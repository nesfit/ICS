using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace GameOfLife
{
    internal class AdWindow : Window
    {
        private readonly DispatcherTimer adTimer;
        private int imgNmb; // the number of the image currently shown
        private string link; // the URL where the currently shown ad leads to

        public AdWindow(Window owner)
        {
            var rnd = new Random();
            Owner = owner;
            Width = 350;
            Height = 100;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.ToolWindow;
            Title = "Support us by clicking the ads";
            Cursor = Cursors.Hand;
            ShowActivated = false;
            MouseDown += OnClick;

            imgNmb = rnd.Next(1, 3);
            ChangeAds(this, new EventArgs());

            // Run the timer that changes the ad's image
            adTimer = new DispatcherTimer();
            adTimer.Interval = TimeSpan.FromSeconds(3);
            adTimer.Tick += ChangeAds;
            adTimer.Start();
        }


        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start(link);
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            //adTimer.Tick -= ChangeAds;
            base.OnClosed(e);
        }

        private void ChangeAds(object sender, EventArgs eventArgs)
        {
            var myBrush = new ImageBrush();

            switch (imgNmb)
            {
                case 1:
                    myBrush.ImageSource =
                        new BitmapImage(new Uri("ad1.png", UriKind.Relative));
                    Background = myBrush;
                    link = "http://example.com";
                    imgNmb++;
                    break;

                case 2:
                    myBrush.ImageSource =
                        new BitmapImage(new Uri("ad2.png", UriKind.Relative));
                    Background = myBrush;
                    link = "http://example.com";
                    imgNmb++;
                    break;

                case 3:
                    myBrush.ImageSource =
                        new BitmapImage(new Uri("ad3.png", UriKind.Relative));
                    Background = myBrush;
                    link = "http://example.com";
                    imgNmb = 1;
                    break;
            }
        }
    }
}