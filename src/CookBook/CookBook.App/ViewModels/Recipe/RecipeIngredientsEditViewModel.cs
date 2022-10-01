using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using System.Collections.ObjectModel;

namespace CookBook.App.ViewModels;


[QueryProperty(nameof(Recipe), nameof(Recipe))]
public class RecipeIngredientsEditViewModel : ViewModelBase
{
    private readonly IngredientFacade ingredientFacade;

    public RecipeDetailModel Recipe { get; set; }
    public List<Unit> Units { get; set; }
    public IEnumerable<IngredientListModel> Ingredients { get; set; }
    public IngredientAmountDetailModel? IngredientAmountNew { get; private set; }

    public RecipeIngredientsEditViewModel(IngredientFacade ingredientFacade)
    {
        this.ingredientFacade = ingredientFacade;
        Units = new List<Unit>((Unit[])Enum.GetValues(typeof(Unit)));
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredients = await ingredientFacade.GetAsync();
    }
}