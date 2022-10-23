using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class IngredientDetailViewModel : ViewModelBase
{
    private readonly IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade;
    
    public Guid Id { get; set; }
    public IngredientDetailModel Ingredient { get; set; }

    public IngredientDetailViewModel(IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade)
    {
        this.ingredientFacade = ingredientFacade;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredient = await ingredientFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        await ingredientFacade.DeleteAsync(Id);
        Shell.Current.SendBackButtonPressed();
    }

    [RelayCommand]
    private async Task GoToEditAsync()
    {
        await Shell.Current.GoToAsync("/edit",
            new Dictionary<string, object> { [nameof(IngredientEditViewModel.Ingredient)] = Ingredient });
    }
}