using CookBook.App.Models;
using CookBook.App.ViewModels;
using CookBook.App.Views.Recipe;

namespace CookBook.App.Services;

public class RoutingService : IRoutingService
{
    public IEnumerable<RouteModel> Routes { get; } = new List<RouteModel>()
    {
        new("//recipes", typeof(RecipeListView), typeof(RecipeListViewModel)),
    };

    public string GetRouteByViewModel<TViewModel>()
        where TViewModel : IViewModel 
        => Routes.First(route => route.ViewModelType == typeof(TViewModel)).Route;
}