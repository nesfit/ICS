using System.Collections.ObjectModel;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.BL.Extensions;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class RecipeListViewModel : ViewModelBase, IRecipeListViewModel
    {
        private readonly IMediator _mediator;
        private readonly IRecipeRepository _recipesRepository;

        public RecipeListViewModel(IRecipeRepository recipesRepository, IMediator mediator)
        {
            this._recipesRepository = recipesRepository;
            this._mediator = mediator;

            RecipeSelectedCommand = new RelayCommand<RecipeListModel>(RecipeSelected);
            RecipeNewCommand = new RelayCommand(RecipeNew);

            mediator.Register<RecipeUpdatedMessage>(RecipeUpdated);
            mediator.Register<RecipeDeletedMessage>(RecipeDeleted);
        }

        public ObservableCollection<RecipeListModel> Recipes { get; } = new ObservableCollection<RecipeListModel>();

        public ICommand RecipeNewCommand { get; }

        public ICommand RecipeSelectedCommand { get; }

        private void RecipeDeleted(RecipeDeletedMessage obj) => Load();

        private void RecipeUpdated(RecipeUpdatedMessage obj) => Load();

        private void RecipeNew() => _mediator.Send(new RecipeNewMessage());

        private void RecipeSelected(RecipeListModel recipeListModel) => _mediator.Send(new RecipeSelectedMessage {Id = recipeListModel.Id});

        public override void Load()
        {
            Recipes.Clear();
            var recipes = _recipesRepository.GetAll();
            Recipes.AddRange(recipes);
        }
    }
}