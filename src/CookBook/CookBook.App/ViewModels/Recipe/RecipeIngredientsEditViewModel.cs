using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using System.Collections.ObjectModel;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecipeIngredientsEditViewModel(
    IIngredientFacade ingredientFacade,
    IRecipeFacade recipeFacade,
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
    public partial IngredientAmountListModel? IngredientAmountNew { get; set; }

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
            IngredientAmountNew.IngredientId = IngredientSelected.Id;
            IngredientAmountNew.IngredientName = IngredientSelected.Name;
            IngredientAmountNew.IngredientImageUrl = IngredientSelected.ImageUrl;

            await recipeFacade.AddIngredientAsync(Recipe.Id, IngredientAmountNew);
            Recipe.Ingredients.Add(IngredientAmountNew);

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
            await recipeFacade.UpdateIngredientAsync(Recipe.Id, model);

            MessengerService.Send(new RecipeIngredientEditMessage());
        }
    }

    [RelayCommand]
    private async Task RemoveIngredientAsync(IngredientAmountListModel model)
    {
        if (Recipe is not null)
        {
            await recipeFacade.RemoveIngredientAsync(model.Id);
            Recipe.Ingredients.Remove(model);

            MessengerService.Send(new RecipeIngredientDeleteMessage());
        }
    }

    private IngredientAmountListModel GetIngredientAmountNew()
    {
        var ingredientFirst = Ingredients.First();
        return new()
        {
            Id = Guid.NewGuid(),
            IngredientId = ingredientFirst.Id,
            IngredientName = ingredientFirst.Name,
            IngredientImageUrl = ingredientFirst.ImageUrl,
            Amount = 0,
            Unit = Unit.None,
        };
    }
}
