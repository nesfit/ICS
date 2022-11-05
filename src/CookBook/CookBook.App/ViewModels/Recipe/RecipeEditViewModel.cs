using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Recipe), nameof(Recipe))]
public partial class RecipeEditViewModel : ViewModelBase
{
    private readonly IRecipeFacade recipeFacade;
    private readonly INavigationService navigationService;

    public RecipeDetailModel Recipe { get; set; } = RecipeDetailModel.Empty;

    public List<FoodType> FoodTypes { get; set; }

    public RecipeEditViewModel(
        IRecipeFacade recipeFacade,
        INavigationService navigationService)
    {
        this.recipeFacade = recipeFacade;
        this.navigationService = navigationService;

        FoodTypes = new List<FoodType>((FoodType[])Enum.GetValues(typeof(FoodType)));
    }

    [RelayCommand]
    private async Task GoToRecipeIngredientEditAsync()
    {
        await navigationService.GoToAsync("/ingredients",
            new Dictionary<string, object?> { [nameof(RecipeIngredientsEditViewModel.Recipe)] = Recipe });
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await recipeFacade.SaveAsync(Recipe);

        navigationService.SendBackButtonPressed();
    }
}