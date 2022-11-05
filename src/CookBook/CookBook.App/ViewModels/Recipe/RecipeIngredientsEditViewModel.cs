using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using System.Collections.ObjectModel;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Recipe), nameof(Recipe))]
public partial class RecipeIngredientsEditViewModel : ViewModelBase
{
    private readonly IIngredientFacade ingredientFacade;
    private readonly IIngredientAmountFacade ingredientAmountFacade;
    private readonly IIngredientAmountModelMapper ingredientAmountModelMapper;

    public RecipeDetailModel Recipe { get; set; }
    public List<Unit> Units { get; set; }
    public ObservableCollection<IngredientListModel> Ingredients { get; set; } = new();

    public IngredientListModel? IngredientSelected { get; set; }

    public IngredientAmountDetailModel? IngredientAmountNew { get; private set; }

    public RecipeIngredientsEditViewModel(
        IIngredientFacade ingredientFacade,
        IIngredientAmountFacade ingredientAmountFacade,
        IIngredientAmountModelMapper ingredientAmountModelMapper)
    {
        this.ingredientFacade = ingredientFacade;
        this.ingredientAmountFacade = ingredientAmountFacade;
        this.ingredientAmountModelMapper = ingredientAmountModelMapper;

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
            ingredientAmountModelMapper.MapToExistingDetailModel(IngredientAmountNew, IngredientSelected);

            await ingredientAmountFacade.SaveAsync(IngredientAmountNew, Recipe.Id);
            Recipe.Ingredients.Add(ingredientAmountModelMapper.MapToListModel(IngredientAmountNew));

            IngredientAmountNew = GetIngredientAmountNew();
        }
    }

    [RelayCommand]
    private async Task UpdateIngredientAsync(IngredientAmountListModel? model)
    {
        if (model is not null)
        {
            await ingredientAmountFacade.SaveAsync(model, Recipe.Id);
        }
    }

    [RelayCommand]
    private async Task RemoveIngredientAsync(IngredientAmountListModel model)
    {
        await ingredientAmountFacade.DeleteAsync(model.Id);
        Recipe.Ingredients.Remove(model);
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