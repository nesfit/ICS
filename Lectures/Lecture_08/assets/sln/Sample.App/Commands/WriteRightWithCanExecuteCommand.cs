using System;
using System.Windows.Input;
using Sample.App.ViewModels;

namespace Sample.App.Commands
{
    public class WriteRightWithCanExecuteCommand : ICommand
    {
        private readonly MainViewModel mainViewModel;

        public WriteRightWithCanExecuteCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(parameter as string);
        }

        public void Execute(object parameter)
        {
            mainViewModel.RightText = parameter as string;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}