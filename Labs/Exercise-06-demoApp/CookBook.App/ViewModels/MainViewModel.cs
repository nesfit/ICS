namespace CookBook.App.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel(
            IIngredientListViewModel ingredientListViewModel,
            IIngredientDetailViewModel ingredientDetailViewModel, 
            IRecipeListViewModel recipeListViewModel,
            IRecipeDetailViewModel recipeDetailViewModel)
        {
            IngredientListViewModel = ingredientListViewModel;
            IngredientDetailViewModel = ingredientDetailViewModel;
            RecipeListViewModel = recipeListViewModel;
            RecipeDetailViewModel = recipeDetailViewModel;
        }

        public IIngredientListViewModel IngredientListViewModel { get; }

        public IIngredientDetailViewModel IngredientDetailViewModel { get; }

        public IRecipeListViewModel RecipeListViewModel { get; }

        public IRecipeDetailViewModel RecipeDetailViewModel { get; }
    }
}