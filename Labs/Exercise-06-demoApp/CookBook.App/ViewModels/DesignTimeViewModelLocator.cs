using CookBook.App.Services;
using CookBook.App.Services.MessageDialog;
using CookBook.BL.Repositories;
using CookBook.DAL.Factories;

namespace CookBook.App.ViewModels
{
    public class DesignTimeViewModelLocator
    {
        public IngredientListViewModel IngredientListViewModel { get; }
        public RecipeListViewModel RecipeListViewModel { get; }
        public IngredientAmountDetailViewModel IngredientAmountDetailViewModel { get; set; }
        public IngredientDetailViewModel IngredientDetailViewModel { get; set; }

        public DesignTimeViewModelLocator()
        {
            var ingredientRepository = new IngredientRepository(new DesignTimeDbContextFactory());
            var recipeRepository = new RecipeRepository(new DesignTimeDbContextFactory());
            var mediator = new Mediator();
            var messageDialogService = new MessageDialogService();

            IngredientAmountDetailViewModel = new IngredientAmountDetailViewModel(ingredientRepository, mediator);
            IngredientListViewModel = new IngredientListViewModel(ingredientRepository, mediator);
            RecipeListViewModel = new RecipeListViewModel(recipeRepository, mediator);
            IngredientDetailViewModel = new IngredientDetailViewModel(ingredientRepository, messageDialogService, mediator);
        }
    }
}