using CookBook.App.Models;
using CookBook.App.ViewModels;
using CookBook.App.Views.Ingredient;
using CookBook.App.Views.Recipe;

namespace CookBook.App.Services;

public class RoutingService : IRoutingService
{
    public IEnumerable<RouteModel> Routes { get; } = new List<RouteModel>
    {
        new("//ingredients", typeof(IngredientListView), typeof(IngredientListViewModel)),
        new("//ingredients/detail", typeof(IngredientDetailView), typeof(IngredientDetailViewModel)),

        new("//recipes", typeof(RecipeListView), typeof(RecipeListViewModel)),
        new("//recipes/detail", typeof(RecipeDetailView), typeof(RecipeDetailViewModel)),
    };

    public string GetRouteByViewModel<TViewModel>()
        where TViewModel : IViewModel 
        => Routes.First(route => route.ViewModelType == typeof(TViewModel)).Route;
}