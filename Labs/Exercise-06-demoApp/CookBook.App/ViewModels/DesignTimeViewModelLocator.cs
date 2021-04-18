using CookBook.App.Factories;
using CookBook.App.Services;
using CookBook.App.Services.MessageDialog;
using CookBook.BL.Repositories;
using CookBook.DAL.Factories;

namespace CookBook.App.ViewModels
{
    public class DesignTimeViewModelLocator
    {
        private const string DesignTimeConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = CookBook;
                MultipleActiveResultSets = True;
                Integrated Security = True; ";

        public IngredientListViewModel IngredientListViewModel { get; }
        public RecipeListViewModel RecipeListViewModel { get; }
        public IngredientAmountDetailViewModel IngredientAmountDetailViewModel { get; set; }
        public IngredientDetailViewModel IngredientDetailViewModel { get; set; }

        public DesignTimeViewModelLocator()
        {
            var ingredientRepository = new IngredientRepository(new SqlServerDbContextFactory(DesignTimeConnectionString));
            var recipeRepository = new RecipeRepository(new SqlServerDbContextFactory(DesignTimeConnectionString));
            var mediator = new Mediator();
            var messageDialogService = new MessageDialogService();

            IngredientAmountDetailViewModel = new IngredientAmountDetailViewModel(ingredientRepository, mediator);
            IngredientListViewModel = new IngredientListViewModel(ingredientRepository, mediator);
            RecipeListViewModel = new RecipeListViewModel(recipeRepository, mediator);
            IngredientDetailViewModel = new IngredientDetailViewModel(ingredientRepository, messageDialogService, mediator);
        }
    }
}