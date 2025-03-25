using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.App.Services;

namespace CookBook.App.ViewModels;

public abstract class ViewModelBase : ObservableRecipient
{
    protected readonly IMessengerService MessengerService;
    protected bool ForceDataRefresh = true;

    protected ViewModelBase(IMessengerService messengerService)
        : base(messengerService.Messenger)
    {
        MessengerService = messengerService;

        IsActive = true;
    }

    public async Task OnAppearingAsync()
    {
        if (ForceDataRefresh)
        {
            await LoadDataAsync();

            ForceDataRefresh = false;
        }
    }

    protected virtual Task LoadDataAsync()
        => Task.CompletedTask;
}
