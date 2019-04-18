using System.Globalization;
using System.Threading;
using System.Windows;

namespace CookBook.App
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");
        }
    }
}