using System;
using CookBook.App.Extensions;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.App.Wrappers;
using CookBook.BL.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.BL.Facades;
using CookBook.Common.Enums;

namespace CookBook.App.ViewModels
{
    public class RecipeListViewModel : ViewModelBase, IRecipeListViewModel
    {
        private readonly RecipeFacade _recipeFacade;
        private readonly IMediator _mediator;

        public RecipeListViewModel(RecipeFacade recipeFacade, IMediator mediator)
        {
            _recipeFacade = recipeFacade;
            _mediator = mediator;

            RecipeSelectedCommand = new RelayCommand<RecipeListModel>(RecipeSelected);
            RecipeNewCommand = new RelayCommand(RecipeNew);

            mediator.Register<UpdateMessage<RecipeWrapper>>(RecipeUpdated);
            mediator.Register<DeleteMessage<RecipeWrapper>>(RecipeDeleted);
        }

        public ObservableCollection<RecipeListModel> Recipes { get; } = new();

        public ICommand RecipeNewCommand { get; }

        public ICommand RecipeSelectedCommand { get; }

        private async void RecipeDeleted(DeleteMessage<RecipeWrapper> _) => await LoadAsync();

        private async void RecipeUpdated(UpdateMessage<RecipeWrapper> _) => await LoadAsync();

        private void RecipeNew() => _mediator.Send(new NewMessage<RecipeWrapper>());

        private void RecipeSelected(RecipeListModel? recipeListModel)
        {
            if (recipeListModel is not null)
            {
                _mediator.Send(new SelectedMessage<RecipeWrapper> { Id = recipeListModel.Id });
            }
        }

        public async Task LoadAsync()
        {
            Recipes.Clear();
            var recipes = await _recipeFacade.GetAsync();
            Recipes.AddRange(recipes);
        }

        public override void LoadInDesignMode()
        {
            Recipes.Add(new RecipeListModel(
                Name: "Spaghetti",
                Duration: TimeSpan.FromMinutes(30),
                FoodType.MainDish)
                { ImageUrl = "https://cleanfoodcrush.com/wp-content/uploads/2019/01/CleanFoodCrush-Super-Easy-Beef-Stir-Fry-Recipe.jpg" });
        }
    }
}