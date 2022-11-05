using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.App.ViewModels;

namespace CookBook.App.Shells;

public partial class AppShell
{
    private readonly INavigationService navigationService;

    public AppShell(INavigationService navigationService)
    {
        this.navigationService = navigationService;

        InitializeComponent();
    }

    [RelayCommand]
    private async Task GoToRecipesAsync()
        => await navigationService.GoToAsync<RecipeListViewModel>();

    [RelayCommand]
    private async Task GoToIngredientsAsync()
        => await navigationService.GoToAsync<IngredientListViewModel>();
}