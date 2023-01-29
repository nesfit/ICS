using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.App.Services;

namespace CookBook.App.ViewModels;

public abstract class ViewModelBase : ObservableRecipient, IViewModel
{
    private bool isRefreshRequired = true;

    protected readonly IMessengerService messengerService;

    protected ViewModelBase(IMessengerService messengerService)
        : base(messengerService.Messenger)
    {
        this.messengerService = messengerService;
        IsActive = true;
    }

    public async Task OnAppearingAsync()
    {
        if (isRefreshRequired)
        {
            await LoadDataAsync();

            isRefreshRequired = false;
        }
    }

    protected virtual Task LoadDataAsync()
        => Task.CompletedTask;
}