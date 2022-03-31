using System.Windows;

namespace CustomControl
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckedSubmitButton_OnClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You just used custom control!");
        }
    }
}