using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Ingredient), nameof(Ingredient))]
public partial class IngredientEditViewModel : ViewModelBase
{
    private readonly IngredientFacade ingredientFacade;

    public IngredientDetailModel Ingredient { get; set; } = IngredientDetailModel.Empty;

    public IngredientEditViewModel(IngredientFacade ingredientFacade)
    {
        this.ingredientFacade = ingredientFacade;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await ingredientFacade.SaveAsync(Ingredient);

        Shell.Current.SendBackButtonPressed();
    }
}