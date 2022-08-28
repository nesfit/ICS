using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.App.ViewModels.Recipe;

namespace CookBook.App.Shells;

public partial class AppShell
{
    private readonly IRoutingService routingService;

    public AppShell(IRoutingService routingService)
    {
        this.routingService = routingService;

        InitializeComponent();
    }

    [RelayCommand]
    private async Task GoToRecipesAsync()
    {
        var route = routingService.GetRouteByViewModel<RecipeListViewModel>();
        await Shell.Current.GoToAsync(route);
    }
}