using System;
using System.Windows;

namespace CookBook.App.Services
{
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button);
    }
}