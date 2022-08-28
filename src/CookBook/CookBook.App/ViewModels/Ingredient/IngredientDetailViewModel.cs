using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class IngredientDetailViewModel : ViewModelBase
{
    private readonly IngredientFacade ingredientFacade;
    
    public Guid Id { get; set; }
    public IngredientDetailModel Ingredient { get; set; }

    public IngredientDetailViewModel(IngredientFacade ingredientFacade)
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
    }
}