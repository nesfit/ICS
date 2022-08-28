using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.App.ViewModels;

[INotifyPropertyChanged]
public abstract partial class ViewModelBase : IViewModel
{
    public bool IsRefreshRequired { get; set; } = true;

    public async Task OnAppearingAsync()
    {
        if (IsRefreshRequired)
        {
            await LoadDataAsync();

            IsRefreshRequired = false;
        }
    }

    protected virtual Task LoadDataAsync()
        => Task.CompletedTask;
}