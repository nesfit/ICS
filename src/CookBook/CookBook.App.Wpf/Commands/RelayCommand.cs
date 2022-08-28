using System;
using System.Windows.Input;

namespace CookBook.App.Commands
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Microsoft.Toolkit.Mvvm.Input.RelayCommand<T> _relayCommand;

        public RelayCommand(Action<T?> execute, Predicate<T?>? canExecute = null)
        {
            _relayCommand = canExecute is null ? new Microsoft.Toolkit.Mvvm.Input.RelayCommand<T>(execute) : new Microsoft.Toolkit.Mvvm.Input.RelayCommand<T>(execute, canExecute);
        }

        public bool CanExecute(object? parameter) => _relayCommand.CanExecute(parameter);

        public void Execute(object? parameter) => _relayCommand.Execute(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
    
    public class RelayCommand : ICommand
    {
        private readonly Microsoft.Toolkit.Mvvm.Input.RelayCommand _relayCommand;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _relayCommand = canExecute is null ? new Microsoft.Toolkit.Mvvm.Input.RelayCommand(execute) : new Microsoft.Toolkit.Mvvm.Input.RelayCommand(execute, canExecute);
        }

        public bool CanExecute(object? parameter) => _relayCommand.CanExecute(parameter);

        public void Execute(object? parameter) => _relayCommand.Execute(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
