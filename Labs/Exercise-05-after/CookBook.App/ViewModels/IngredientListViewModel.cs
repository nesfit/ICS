using CookBook.App.Commands;
using CookBook.App.Extensions;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.App.Wrappers;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        public ObservableCollection<IngredientListModel> Ingredients { get; set; } = new ObservableCollection<IngredientListModel>();

        public ICommand IngredientSelectedCommand { get; }
        public ICommand IngredientNewCommand { get; }

        private void IngredientNew() => _mediator.Send(new NewMessage<IngredientWrapper>());

        private void IngredientSelected(IngredientListModel ingredient) => _mediator.Send(new SelectedMessage<IngredientWrapper> { Id = ingredient.Id });

        private void IngredientUpdated(UpdateMessage<IngredientWrapper> _) => Load();

        private void IngredientDeleted(DeleteMessage<IngredientWrapper> _) => Load();

        public void Load()
        {
            Ingredients.Clear();
            var ingredients = _ingredientRepository.GetAll();
            Ingredients.AddRange(ingredients);
        }

        public override void LoadInDesignMode()
        {
            Ingredients.Add(new IngredientListModel { Name = "Voda", ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png" });
        }
    }
}
