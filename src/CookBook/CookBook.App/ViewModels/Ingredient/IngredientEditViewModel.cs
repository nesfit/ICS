using CommunityToolkit.Mvvm.Input;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Ingredient), nameof(Ingredient))]
public partial class IngredientEditViewModel : ViewModelBase
{
    private readonly IIngredientFacade _ingredientFacade;
    private readonly INavigationService _navigationService;

    public IngredientDetailModel Ingredient { get; init; } = IngredientDetailModel.Empty;

    public IngredientEditViewModel(
        IIngredientFacade ingredientFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : base(messengerService)
    {
        _ingredientFacade = ingredientFacade;
        _navigationService = navigationService;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await _ingredientFacade.SaveAsync(Ingredient);

        MessengerService.Send(new IngredientEditMessage { IngredientId = Ingredient.Id });

        _navigationService.SendBackButtonPressed();
    }
}
