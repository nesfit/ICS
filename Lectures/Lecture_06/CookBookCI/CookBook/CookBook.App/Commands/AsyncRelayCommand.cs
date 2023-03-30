using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;

namespace CookBook.App.Commands;

public class AsyncRelayCommand<T> : IAsyncRelayCommand<T>
{
    private readonly Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand<T> _relayCommand;

    public AsyncRelayCommand(Func<T?, CancellationToken, Task> cancelableExecute, Predicate<T?> canExecute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand<T>(cancelableExecute, canExecute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }

    public AsyncRelayCommand(Func<T?, Task> execute, Predicate<T?> canExecute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand<T>(execute, canExecute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }
    
    public AsyncRelayCommand(Func<T?, Task> execute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand<T>(execute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }
    
    public AsyncRelayCommand(Func<T?, CancellationToken, Task> cancelableExecute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand<T>(cancelableExecute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }

    public async Task ExecuteAsync(T? parameter) => await _relayCommand.ExecuteAsync(parameter);

    public bool CanExecute(object? parameter) => _relayCommand.CanExecute(parameter);

    public void Execute(object? parameter) => _relayCommand.Execute(parameter);

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void NotifyCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

    public event PropertyChangedEventHandler? PropertyChanged;
    public async Task ExecuteAsync(object? parameter) => await _relayCommand.ExecuteAsync(parameter);
    public void Cancel() => _relayCommand.Cancel();
    public Task? ExecutionTask => _relayCommand.ExecutionTask;
    public bool CanBeCanceled => _relayCommand.CanBeCanceled;
    public bool IsCancellationRequested => _relayCommand.IsCancellationRequested;
    public bool IsRunning => _relayCommand.IsRunning;
    public bool CanExecute(T? parameter)=> _relayCommand.CanExecute(parameter);

    public void Execute(T? parameter)=> _relayCommand.Execute(parameter);
}

public class AsyncRelayCommand : IAsyncRelayCommand
{
    private readonly Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand _relayCommand;

    public AsyncRelayCommand(Func<Task> execute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand(execute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }
    
    public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand(execute, canExecute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }

    public AsyncRelayCommand(Func<CancellationToken, Task> cancelableExecute, Func<bool> canExecute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand(cancelableExecute, canExecute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }
    
    public AsyncRelayCommand(Func<CancellationToken, Task> cancelableExecute)
    {
        _relayCommand = new Microsoft.Toolkit.Mvvm.Input.AsyncRelayCommand(cancelableExecute);
        _relayCommand.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
    }
    

    public bool CanExecute(object? parameter) => _relayCommand.CanExecute(parameter);

    public void Execute(object? parameter) => _relayCommand.Execute(parameter);

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void NotifyCanExecuteChanged()=> CommandManager.InvalidateRequerySuggested();

    public event PropertyChangedEventHandler? PropertyChanged;
    public async Task ExecuteAsync(object? parameter) => await _relayCommand.ExecuteAsync(parameter);

    public void Cancel() => _relayCommand.Cancel();

    public Task? ExecutionTask => _relayCommand.ExecutionTask;
    public bool CanBeCanceled => _relayCommand.CanBeCanceled;
    public bool IsCancellationRequested => _relayCommand.IsCancellationRequested;
    public bool IsRunning => _relayCommand.IsRunning;
}