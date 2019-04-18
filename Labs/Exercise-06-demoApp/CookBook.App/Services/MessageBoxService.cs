using System;
using System.Windows;

namespace CookBook.App.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult Show(String messageBoxText, String caption, MessageBoxButton button) => MessageBox.Show(messageBoxText, caption, button);
    }
}