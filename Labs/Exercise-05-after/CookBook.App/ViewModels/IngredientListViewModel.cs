using CookBook.App.Commands;
using CookBook.App.Extensions;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

            _mediator.Register<AddedMessage>(IngredientAdded);
            _mediator.Register<UpdateMessage>(IngredientUpdated);
            _mediator.Register<DeleteMessage>(IngredientDeleted);
        }

        private void IngredientNew()
            => _mediator.Send(new NewMessage());

        private void IngredientSelected(IngredientListModel ingredient)
            => _mediator.Send(new SelectedMessage { Id = ingredient.Id });

        private void IngredientAdded(AddedMessage item) => Load();

        private void IngredientUpdated(UpdateMessage ingredient) => Load();

        private void IngredientDeleted(DeleteMessage item) => Load();

        public override void Load()
        {
            Ingredients.Clear();
            Ingredients.AddRange(_ingredientRepository.GetAll());
        }
    }
}
