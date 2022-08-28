using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

public partial class IngredientListViewModel : ViewModelBase
{
    private readonly IngredientFacade ingredientFacade;
    
    public IEnumerable<IngredientListModel> Ingredients { get; set; }

    public IngredientListViewModel(IngredientFacade ingredientFacade)
    {
        this.ingredientFacade = ingredientFacade;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredients = await ingredientFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
    }
}