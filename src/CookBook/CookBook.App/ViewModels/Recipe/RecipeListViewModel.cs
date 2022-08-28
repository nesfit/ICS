using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

public partial class RecipeListViewModel : ViewModelBase
{
    private readonly RecipeFacade recipeFacade;

    public IEnumerable<RecipeListModel> Recipes { get; set; }

    public RecipeListViewModel(RecipeFacade recipeFacade)
    {
        this.recipeFacade = recipeFacade;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Recipes = await recipeFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToDetailAsync()
    {
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
    }
}