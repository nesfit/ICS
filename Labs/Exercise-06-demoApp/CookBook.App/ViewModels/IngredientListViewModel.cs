using System.Collections.ObjectModel;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.BL.Extensions;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class IngredientListViewModel : ViewModelBase
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMediator mediator;

        public IngredientListViewModel(IIngredientRepository ingredientRepository, IMediator mediator)
        {
            this.ingredientRepository = ingredientRepository;
            this.mediator = mediator;

            IngredientSelectedCommand = new RelayCommand<IngredientListModel>(IngredientSelected);
            IngredientNewCommand = new RelayCommand(IngredientNew);

            mediator.Register<IngredientUpdatedMessage>(IngredientUpdated);
            mediator.Register<IngredientDeletedMessage>(IngredientDeleted);
        }

        public ObservableCollection<IngredientListModel> Ingredients { get; } = new ObservableCollection<IngredientListModel>();

        public ICommand IngredientSelectedCommand { get; }
        public ICommand IngredientNewCommand { get; }

        private void IngredientNew() => mediator.Send(new IngredientNewMessage());

        private void IngredientSelected(IngredientListModel ingredient) => mediator.Send(new IngredientSelectedMessage {Id = ingredient.Id});

        private void IngredientUpdated(IngredientUpdatedMessage ingredient) => Load();

        private void IngredientDeleted(IngredientDeletedMessage ingredient) => Load();

        public override void Load()
        {
            Ingredients.Clear();
            var ingredients = ingredientRepository.GetAll();
            Ingredients.AddRange(ingredients);
        }
    }
}