using System.Collections.ObjectModel;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Wrappers;
using CookBook.BL.Extensions;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class IngredientListViewModel : ViewModelBase, IIngredientListViewModel
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMediator _mediator;

        public IngredientListViewModel(IIngredientRepository ingredientRepository, IMediator mediator)
        {
            _ingredientRepository = ingredientRepository;
            _mediator = mediator;

            IngredientSelectedCommand = new RelayCommand<IngredientListModel>(IngredientSelected);
            IngredientNewCommand = new RelayCommand(IngredientNew);

            mediator.Register<UpdateMessage<IngredientWrapper>>(IngredientUpdated);
            mediator.Register<DeleteMessage<IngredientWrapper>>(IngredientDeleted);
        }

        public ObservableCollection<IngredientListModel> Ingredients { get; } = new ObservableCollection<IngredientListModel>();

        public ICommand IngredientSelectedCommand { get; }
        public ICommand IngredientNewCommand { get; }

        private void IngredientNew() => _mediator.Send(new NewMessage<IngredientWrapper>());

        private void IngredientSelected(IngredientListModel ingredient) => _mediator.Send(new SelectedMessage<IngredientWrapper> {Id = ingredient.Id});

        private void IngredientUpdated(UpdateMessage<IngredientWrapper> _) => Load();

        private void IngredientDeleted(DeleteMessage<IngredientWrapper> _) => Load();

        public void Load()
        {
            Ingredients.Clear();
            var ingredients = _ingredientRepository.GetAll();
            Ingredients.AddRange(ingredients);
        }
    }
}