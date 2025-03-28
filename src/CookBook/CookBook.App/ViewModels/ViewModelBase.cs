using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.App.Services;

namespace CookBook.App.ViewModels;

public abstract class ViewModelBase : ObservableRecipient
{
    private bool forceDataRefresh = true;

    protected readonly IMessengerService MessengerService;

    protected ViewModelBase(IMessengerService messengerService)
        : base(messengerService.Messenger)
    {
        MessengerService = messengerService;

        IsActive = true;
    }

    public async Task OnAppearingAsync()
    {
        if (forceDataRefresh)
        {
            await LoadDataAsync();

            forceDataRefresh = false;
        }
    }

    protected void ForceDataRefreshOnNextAppearing()
    {
        forceDataRefresh = true;
    }

    protected virtual Task LoadDataAsync()
        => Task.CompletedTask;
}
