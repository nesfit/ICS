using CookBook.BL.Models;
using CookBook.BL.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.BL.Extensions;
using CookBook.BL.Messages;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMediator mediator;

        public ObservableCollection<IngredientListModel> Ingredients { get; set; } = new ObservableCollection<IngredientListModel>();

        public ICommand IngredientSelectedCommand { get; set; }
        public ICommand IngredientNewCommand { get; set; }

        public IngredientListViewModel(IIngredientRepository ingredientRepository, IMediator mediator)
        {
            this.ingredientRepository = ingredientRepository;
            this.mediator = mediator;

            IngredientSelectedCommand = new RelayCommand<IngredientListModel>(IngredientSelected);
            IngredientNewCommand = new RelayCommand(IngredientNew);

            mediator.Register<IngredientAddedMessage>(IngredientAdded);
            mediator.Register<IngredientUpdatedMessage>(IngredientUpdated);
            mediator.Register<IngredientDeletedMessage>(IngredientDeleted);
        }

        private void IngredientNew()
        {
            mediator.Send(new IngredientNewMessage());
        }

        private void IngredientSelected(IngredientListModel ingredient)
        {
            mediator.Send(new IngredientSelectedMessage { Id = ingredient.Id });
        }

        private void IngredientAdded(IngredientAddedMessage ingredient)
        {
            Load();
        }

        private void IngredientUpdated(IngredientUpdatedMessage ingredient)
        {
            Load();
        }

        private void IngredientDeleted(IngredientDeletedMessage ingredient)
        {
            Load();
        }

        public override void Load()
        {
            Ingredients.Clear();
            var ingredients = ingredientRepository.GetAll();
            Ingredients.AddRange(ingredients);
        }
    }
}
