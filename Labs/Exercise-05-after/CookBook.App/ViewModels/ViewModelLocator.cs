using CookBook.App.Services;
using CookBook.BL.Factories;
using CookBook.BL.Repositories;
using CookBook.BL.Services;
using Microsoft.EntityFrameworkCore;

namespace CookBook.App.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IMediator mediator;
        private readonly IDbContextFactory dbContextFactory;
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMessageBoxService messageBoxService;

        public IngredientListViewModel IngredientListViewModel => new IngredientListViewModel(ingredientRepository, mediator);
        public IngredientDetailViewModel IngredientDetailViewModel => new IngredientDetailViewModel(ingredientRepository, messageBoxService, mediator);

        public ViewModelLocator()
        {
            mediator = new Mediator();
            dbContextFactory = new DbContextFactory();
            ingredientRepository = new IngredientRepository(dbContextFactory);
            messageBoxService = new MessageBoxService();

            using var dbx = dbContextFactory.CreateDbContext();
            dbx.Database.Migrate();
        }
    }
}
