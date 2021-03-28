using CookBook.App.Services;
using CookBook.BL.Factories;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.App.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IMediator _mediator;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMessageBoxService _messageBoxService;

        public IngredientListViewModel IngredientListViewModel => new(_ingredientRepository, _mediator);
        public IngredientDetailViewModel IngredientDetailViewModel => new(_ingredientRepository, _messageBoxService, _mediator);

        public ViewModelLocator()
        {
            _mediator = new Mediator();
            var dbContextFactory = new DbContextFactory();
            _ingredientRepository = new IngredientRepository(dbContextFactory);
            _messageBoxService = new MessageBoxService();

            using var dbx = dbContextFactory.Create();
            dbx.Database.Migrate();
        }
    }
}
