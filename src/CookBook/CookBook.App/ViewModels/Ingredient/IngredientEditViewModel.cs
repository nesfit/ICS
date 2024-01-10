using CommunityToolkit.Mvvm.Input;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Ingredient), nameof(Ingredient))]
public partial class IngredientEditViewModel(
    IIngredientFacade ingredientFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public IngredientDetailModel Ingredient { get; init; } = IngredientDetailModel.Empty;

    [RelayCommand]
    private async Task SaveAsync()
    {
        await ingredientFacade.SaveAsync(Ingredient);

        MessengerService.Send(new IngredientEditMessage { IngredientId = Ingredient.Id });

        navigationService.SendBackButtonPressed();
    }
}
