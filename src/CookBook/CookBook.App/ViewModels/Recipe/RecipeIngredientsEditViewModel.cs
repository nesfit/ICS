using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using System.Collections.ObjectModel;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Recipe), nameof(Recipe))]
public partial class RecipeIngredientsEditViewModel : ViewModelBase
{
    private readonly IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade;
    private readonly IIngredientAmountFacade ingredientAmountFacade;

    public RecipeDetailModel Recipe { get; set; }
    public List<Unit> Units { get; set; }
    public ObservableCollection<IngredientListModel> Ingredients { get; set; } = new();

    public IngredientListModel? IngredientSelected { get; set; }

    public IngredientAmountDetailModel? IngredientAmountNew { get; private set; }

    public RecipeIngredientsEditViewModel(
        IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade,
        IIngredientAmountFacade ingredientAmountFacade)
    {
        this.ingredientFacade = ingredientFacade;
        this.ingredientAmountFacade = ingredientAmountFacade;

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
        if (IngredientAmountNew is not null
            && IngredientSelected is not null)
        {
            IngredientAmountNew.IngredientId = IngredientSelected.Id;
            IngredientAmountNew.IngredientName = IngredientSelected.Name;
            IngredientAmountNew.IngredientImageUrl = IngredientSelected.ImageUrl;

            await ingredientAmountFacade.SaveAsync(IngredientAmountNew, Recipe.Id);
            Recipe.Ingredients.Add(IngredientAmountNew);

            IngredientAmountNew = GetIngredientAmountNew();
        }
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