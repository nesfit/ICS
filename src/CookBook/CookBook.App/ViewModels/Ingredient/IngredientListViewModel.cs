using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

public partial class IngredientListViewModel : ViewModelBase, IRecipient<IngredientEditMessage>, IRecipient<IngredientDeleteMessage>
{
    private readonly IIngredientFacade _ingredientFacade;
    private readonly INavigationService _navigationService;

    public IEnumerable<IngredientListModel> Ingredients { get; set; } = null!;

    public IngredientListViewModel(
        IIngredientFacade ingredientFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : base(messengerService)
    {
        _ingredientFacade = ingredientFacade;
        _navigationService = navigationService;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredients = await _ingredientFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await _navigationService.GoToAsync("/edit");
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await _navigationService.GoToAsync<IngredientDetailViewModel>(
            new Dictionary<string, object?> { [nameof(IngredientDetailViewModel.Id)] = id });
    }

    public async void Receive(IngredientEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(IngredientDeleteMessage message)
    {
        await LoadDataAsync();
    }
}
