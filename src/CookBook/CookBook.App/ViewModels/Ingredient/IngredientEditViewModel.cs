using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Ingredient), nameof(Ingredient))]
public partial class IngredientEditViewModel : ViewModelBase
{
    private readonly IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade;

    public IngredientDetailModel Ingredient { get; set; } = IngredientDetailModel.Empty;

    public IngredientEditViewModel(IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade)
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