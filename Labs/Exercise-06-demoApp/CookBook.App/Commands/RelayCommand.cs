using System;
using System.Windows.Input;

namespace CookBook.App.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Func<Object, Boolean> canExecuteAction;
        private readonly Action<Object> executeAction;

        public RelayCommand(Action<Object> executeAction, Func<Object, Boolean> canExecuteAction = null)
        {
            this.executeAction = executeAction;
            this.canExecuteAction = canExecuteAction;
        }

        public RelayCommand(Action executeAction, Func<Boolean> canExecuteAction = null)
            : this(p => executeAction(), p => canExecuteAction?.Invoke() ?? true)
        {
        }

        public Boolean CanExecute(Object parameter) => canExecuteAction?.Invoke(parameter) ?? true;

        public void Execute(Object parameter)
        {
            executeAction?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Func<T, Boolean> canExecute;
        private readonly Action<T> execute;

        public RelayCommand(Action<T> execute, Func<T, Boolean> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public Boolean CanExecute(Object parameter)
        {
            if (parameter is T typedParameter)
            {
                return canExecute?.Invoke(typedParameter) ?? true;
            }

            return false;
        }

        public void Execute(Object parameter)
        {
            if (parameter is T typedParameter)
            {
                execute?.Invoke(typedParameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}