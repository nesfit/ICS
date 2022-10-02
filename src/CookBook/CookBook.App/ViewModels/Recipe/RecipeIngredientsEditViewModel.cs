using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using System.Collections.ObjectModel;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Recipe), nameof(Recipe))]
public partial class RecipeIngredientsEditViewModel : ViewModelBase
{
    private readonly IngredientFacade ingredientFacade;

    public RecipeDetailModel Recipe { get; set; }
    public List<Unit> Units { get; set; }
    public ObservableCollection<IngredientListModel> Ingredients { get; set; } = new();

    public IngredientListModel? IngredientNew { get; set; }
    public IngredientAmountDetailModel? IngredientAmountNew { get; private set; }

    public RecipeIngredientsEditViewModel(IngredientFacade ingredientFacade)
    {
        this.ingredientFacade = ingredientFacade;
        Units = new List<Unit>((Unit[])Enum.GetValues(typeof(Unit)));
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredients.Clear();
        var ingredients = await ingredientFacade.GetAsync();
        foreach (var ingredient in ingredients)
        {
            Ingredients.Add(ingredient);
            IngredientAmountNew = GetIngredientAmountNew();
        }
    }

    [RelayCommand]
    private async Task AddNewIngredientToRecipeAsync()
    {
        // TODO: Add implementation
    }

    private IngredientAmountDetailModel GetIngredientAmountNew()
    {
        var ingredientFirst = Ingredients.First();
        return new()
        {
            Id = Guid.NewGuid(),
            IngredientId = ingredientFirst.Id,
            IngredientName = ingredientFirst.Name,
            IngredientDescription = string.Empty,
            Amount = 0,
            Unit = Unit.None,
        };
    }
}