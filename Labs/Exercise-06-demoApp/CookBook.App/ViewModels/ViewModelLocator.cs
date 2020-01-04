using CookBook.App.Services.MessageDialog;
using CookBook.BL.Interfaces;
using CookBook.BL.Repositories;
using CookBook.BL.Services;
using CookBook.DAL.Factories;
using Microsoft.Extensions.Configuration;

namespace CookBook.App.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMediator mediator;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IRecipeRepository recipesRepository;

        public ViewModelLocator()
        {
            var dbContextFactory = CreateDbContextFactory();

#if DEBUG
            using (var dbx = dbContextFactory.CreateDbContext())
            {
                dbx.Database.EnsureCreated();
            }
#endif

            mediator = new Mediator();
            ingredientRepository = new IngredientRepository(dbContextFactory);
            recipesRepository = new RecipeRepository(dbContextFactory);
            _messageDialogService = new MessageDialogService();
        }


        public IngredientListViewModel IngredientListViewModel => new IngredientListViewModel(ingredientRepository, mediator);

        public RecipesListViewModel RecipeListViewModel => new RecipesListViewModel(recipesRepository, mediator);

        public IngredientDetailViewModel IngredientDetailViewModel =>
            new IngredientDetailViewModel(ingredientRepository, _messageDialogService, mediator);

        public RecipeDetailViewModel RecipeDetailViewModel => new RecipeDetailViewModel(recipesRepository, _messageDialogService, mediator);

        public IngredientAmountDetailViewModel IngredientAmountDetailViewModel =>
            new IngredientAmountDetailViewModel(ingredientRepository, mediator);

        private IDbContextFactory CreateDbContextFactory()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json", false, true);

            return new DbContextFactory(builder.Build().GetConnectionString("DefaultConnection"));
        }
    }
}