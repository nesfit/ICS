using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CookBook.App.Services
{
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button);
    }
}
