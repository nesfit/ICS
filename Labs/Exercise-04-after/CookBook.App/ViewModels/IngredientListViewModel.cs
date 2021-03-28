using CookBook.BL.Models;
using CookBook.BL.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Extensions;
using CookBook.App.Messages;
using CookBook.App.Services;

namespace CookBook.App.ViewModels
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMediator _mediator;

        public ObservableCollection<IngredientListModel> Ingredients { get; set; } = new();

        public ICommand IngredientSelectedCommand { get; set; }
        public ICommand IngredientNewCommand { get; set; }

        public IngredientListViewModel(IIngredientRepository ingredientRepository, IMediator mediator)
        {
            _ingredientRepository = ingredientRepository;
            _mediator = mediator;

            IngredientSelectedCommand = new RelayCommand<IngredientListModel>(IngredientSelected);
            IngredientNewCommand = new RelayCommand(IngredientNew);

            _mediator.Register<IngredientAddedMessage>(IngredientAdded);
            _mediator.Register<IngredientUpdatedMessage>(IngredientUpdated);
            _mediator.Register<IngredientDeletedMessage>(IngredientDeleted);
        }

        private void IngredientNew() 
            => _mediator.Send(new IngredientNewMessage());

        private void IngredientSelected(IngredientListModel ingredient) 
            => _mediator.Send(new IngredientSelectedMessage { Id = ingredient.Id });

        private void IngredientAdded(IngredientAddedMessage ingredient) => Load();

        private void IngredientUpdated(IngredientUpdatedMessage ingredient) => Load();

        private void IngredientDeleted(IngredientDeletedMessage ingredient) => Load();

        public override void Load()
        {
            Ingredients.Clear();
            Ingredients.AddRange(_ingredientRepository.GetAll());
        }
    }
}
