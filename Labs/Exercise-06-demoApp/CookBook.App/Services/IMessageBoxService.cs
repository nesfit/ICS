using System;
using System.Windows;

namespace CookBook.App.Services
{
    public interface IMessageBoxService
    {
        MessageBoxResult Show(String messageBoxText, String caption, MessageBoxButton button);
    }
}