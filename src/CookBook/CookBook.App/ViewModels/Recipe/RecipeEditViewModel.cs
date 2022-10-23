using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Recipe), nameof(Recipe))]
public partial class RecipeEditViewModel : ViewModelBase
{
    private readonly IFacade<RecipeEntity, RecipeListModel, RecipeDetailModel, RecipeEntityMapper> recipeFacade;

    public RecipeDetailModel Recipe { get; set; } = RecipeDetailModel.Empty;

    public List<FoodType> FoodTypes { get; set; }

    public RecipeEditViewModel(IFacade<RecipeEntity, RecipeListModel, RecipeDetailModel, RecipeEntityMapper> recipeFacade)
    {
        this.recipeFacade = recipeFacade;

        FoodTypes = new List<FoodType>((FoodType[])Enum.GetValues(typeof(FoodType)));
    }

    [RelayCommand]
    private async Task GoToRecipeIngredientEditAsync()
    {
        await Shell.Current.GoToAsync("/ingredients",
            new Dictionary<string, object>{ [nameof(RecipeIngredientsEditViewModel.Recipe)] = Recipe});
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await recipeFacade.SaveAsync(Recipe);

        Shell.Current.SendBackButtonPressed();
    }
}