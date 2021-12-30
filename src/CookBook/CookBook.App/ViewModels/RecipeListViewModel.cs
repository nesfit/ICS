using CookBook.App.Extensions;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.App.Wrappers;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CookBook.App.Commands;

namespace CookBook.App.ViewModels
{
    public class RecipeListViewModel : ViewModelBase, IRecipeListViewModel
    {
        private readonly IMediator _mediator;
        private readonly IRecipeRepository _recipesRepository;

        public RecipeListViewModel(IRecipeRepository recipesRepository, IMediator mediator)
        {
            _recipesRepository = recipesRepository;
            _mediator = mediator;

            RecipeSelectedCommand = new RelayCommand<RecipeListModel>(RecipeSelected);
            RecipeNewCommand = new RelayCommand(RecipeNew);

            mediator.Register<UpdateMessage<RecipeWrapper>>(RecipeUpdated);
            mediator.Register<DeleteMessage<RecipeWrapper>>(RecipeDeleted);
        }

        public ObservableCollection<RecipeListModel> Recipes { get; } = new ObservableCollection<RecipeListModel>();

        public ICommand RecipeNewCommand { get; }

        public ICommand RecipeSelectedCommand { get; }

        private void RecipeDeleted(DeleteMessage<RecipeWrapper> _) => Load();

        private void RecipeUpdated(UpdateMessage<RecipeWrapper> _) => Load();

        private void RecipeNew() => _mediator.Send(new NewMessage<RecipeWrapper>());

        private void RecipeSelected(RecipeListModel recipeListModel) => _mediator.Send(new SelectedMessage<RecipeWrapper> { Id = recipeListModel.Id });

        public void Load()
        {
            Recipes.Clear();
            var recipes = _recipesRepository.GetAll();
            Recipes.AddRange(recipes);
        }

        public override void LoadInDesignMode()
        {
            Recipes.Add(new RecipeListModel { Name = "Spaghetti", ImageUrl = "https://cleanfoodcrush.com/wp-content/uploads/2019/01/CleanFoodCrush-Super-Easy-Beef-Stir-Fry-Recipe.jpg" });
        }
    }
}