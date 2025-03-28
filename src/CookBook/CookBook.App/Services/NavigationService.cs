using CookBook.App.Models;
using CookBook.App.Views.Ingredient;
using CookBook.App.Views.Recipe;

namespace CookBook.App.Services;

public class NavigationService : INavigationService
{
    public const string RecipeListRouteAbsolute = "//recipes";
    public const string RecipeDetailRouteRelative = "/detail";
    public const string RecipeEditRouteRelative = "/edit";
    public const string RecipeIngredientsEditRouteRelative = "/ingredients";

    public const string IngredientListRouteAbsolute = "//ingredients";
    public const string IngredientDetailRouteRelative = "/detail";
    public const string IngredientEditRouteRelative = "/edit";

    public IEnumerable<RouteModel> Routes { get; } = new List<RouteModel>
    {
        new(IngredientListRouteAbsolute, typeof(IngredientListView)),
        new(IngredientListRouteAbsolute + IngredientDetailRouteRelative, typeof(IngredientDetailView)),
        
        new(IngredientListRouteAbsolute + IngredientEditRouteRelative, typeof(IngredientEditView)),
        new(IngredientListRouteAbsolute + IngredientDetailRouteRelative + IngredientEditRouteRelative, typeof(IngredientEditView)),

        new(RecipeListRouteAbsolute, typeof(RecipeListView)),
        new(RecipeListRouteAbsolute + RecipeDetailRouteRelative, typeof(RecipeDetailView)),

        new(RecipeListRouteAbsolute + RecipeEditRouteRelative, typeof(RecipeEditView)),
        new(RecipeListRouteAbsolute + RecipeDetailRouteRelative + RecipeEditRouteRelative, typeof(RecipeEditView)),

        new(RecipeListRouteAbsolute + RecipeDetailRouteRelative + RecipeEditRouteRelative + RecipeIngredientsEditRouteRelative, typeof(RecipeIngredientsEditView)),
    };

    public async Task GoToAsync(string route)
        => await Shell.Current.GoToAsync(route);

    public async Task GoToAsync(string route, IDictionary<string, object?> parameters)
        => await Shell.Current.GoToAsync(route, parameters);

    public bool SendBackButtonPressed()
        => Shell.Current.SendBackButtonPressed();
}
