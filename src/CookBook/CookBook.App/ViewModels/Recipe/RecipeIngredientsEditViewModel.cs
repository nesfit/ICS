using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using System.Collections.ObjectModel;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecipeIngredientsEditViewModel(
    IIngredientFacade ingredientFacade,
    IIngredientAmountFacade ingredientAmountFacade,
    IRecipeFacade recipeFacade,
    IngredientAmountModelMapper ingredientAmountModelMapper,
    IMessengerService messengerService)
    : ViewModelBase(messengerService)
{
    public Guid Id { get; set; }

    public List<Unit> Units { get; set; } = [.. (Unit[])Enum.GetValues(typeof(Unit))];

    [ObservableProperty]
    public partial RecipeDetailModel? Recipe { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<IngredientListModel> Ingredients { get; set; } = [];

    [ObservableProperty]
    public partial IngredientListModel? IngredientSelected { get; set; }

    [ObservableProperty]
    public partial IngredientAmountDetailModel? IngredientAmountNew { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Recipe = await recipeFacade.GetAsync(Id)
            ?? RecipeDetailModel.Empty;

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
            && IngredientSelected is not null
            && Recipe is not null)
        {
            ingredientAmountModelMapper.MapToExistingDetailModel(IngredientAmountNew, IngredientSelected);

            await ingredientAmountFacade.SaveAsync(IngredientAmountNew, Recipe.Id);
            Recipe.Ingredients.Add(ingredientAmountModelMapper.MapToListModel(IngredientAmountNew));

            IngredientAmountNew = GetIngredientAmountNew();

            MessengerService.Send(new RecipeIngredientAddMessage());
        }
    }

    [RelayCommand]
    private async Task UpdateIngredientAsync(IngredientAmountListModel? model)
    {
        if (model is not null
            && Recipe is not null)
        {
            await ingredientAmountFacade.SaveAsync(model, Recipe.Id);

            MessengerService.Send(new RecipeIngredientEditMessage());
        }
    }

    [RelayCommand]
    private async Task RemoveIngredientAsync(IngredientAmountListModel model)
    {
        if (Recipe is not null)
        {
            await ingredientAmountFacade.DeleteAsync(model.Id);
            Recipe.Ingredients.Remove(model);

            MessengerService.Send(new RecipeIngredientDeleteMessage());
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
