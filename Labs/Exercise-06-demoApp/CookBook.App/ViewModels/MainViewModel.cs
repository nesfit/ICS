using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Factories;
using CookBook.App.Wrappers;
using CookBook.BL.Messages;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFactory<IRecipeDetailViewModel> _recipeDetailViewModelFactory;
        private readonly IFactory<IIngredientDetailViewModel> _ingredientDetailViewModelFactory;

        public MainViewModel(
            IIngredientListViewModel ingredientListViewModel,
            IRecipeListViewModel recipeListViewModel,
            IMediator mediator,
            IFactory<IRecipeDetailViewModel> recipeDetailViewModelFactory,
            IFactory<IIngredientDetailViewModel> ingredientDetailViewModelFactory)
        {
            _recipeDetailViewModelFactory = recipeDetailViewModelFactory;
            _ingredientDetailViewModelFactory = ingredientDetailViewModelFactory;
            IngredientListViewModel = ingredientListViewModel;
            IngredientDetailViewModel = _ingredientDetailViewModelFactory.Create();
            RecipeListViewModel = recipeListViewModel;
            RecipeDetailViewModel = _recipeDetailViewModelFactory.Create();

            CloseRecipeDetailTabCommand = new RelayCommand(OnCloseRecipeDetailTabExecute);
            CloseIngredientDetailTabCommand = new RelayCommand(OnCloseIngredientDetailTabExecute);

            mediator.Register<NewMessage<RecipeWrapper>>(OnRecipeNewMessage);
            mediator.Register<NewMessage<IngredientWrapper>>(OnIngredientNewMessage);

            mediator.Register<SelectedMessage<RecipeWrapper>>(OnRecipeSelected);
            mediator.Register<SelectedMessage<IngredientWrapper>>(OnIngredientSelected);

            mediator.Register<DeleteMessage<IngredientWrapper>>(OnIngredientDeleted);
            mediator.Register<DeleteMessage<RecipeWrapper>>(OnRecipeDeleted);

        }

        public IIngredientListViewModel IngredientListViewModel { get; }

        public IIngredientDetailViewModel IngredientDetailViewModel { get; }

        public IRecipeListViewModel RecipeListViewModel { get; }

        public IRecipeDetailViewModel RecipeDetailViewModel { get; }


        public ObservableCollection<IRecipeDetailViewModel> RecipeDetailViewModels { get; } =
            new ObservableCollection<IRecipeDetailViewModel>();

        public ObservableCollection<IIngredientDetailViewModel> IngredientDetailViewModels { get; } = new ObservableCollection<IIngredientDetailViewModel>();


        public IRecipeDetailViewModel SelectedRecipeDetailViewModel { get; set; }
        public IIngredientDetailViewModel SelectedIngredientDetailViewModel { get; set; }


        public ICommand CloseRecipeDetailTabCommand { get; }

        public ICommand CloseIngredientDetailTabCommand { get; }

        private void OnRecipeNewMessage(NewMessage<RecipeWrapper> _)
        {
            SelectRecipe(Guid.Empty);
        }

        private void OnIngredientNewMessage(NewMessage<IngredientWrapper> _)
        {
            SelectIngredient(Guid.Empty);
        }

        private void OnRecipeSelected(SelectedMessage<RecipeWrapper> message)
        {
            SelectRecipe(message.Id);
        }

        private void OnIngredientSelected(SelectedMessage<IngredientWrapper> message)
        {
            SelectIngredient(message.Id);
        }

        private void OnRecipeDeleted(DeleteMessage<RecipeWrapper> message)
        {
            var recipe = RecipeDetailViewModels.SingleOrDefault(i => i.Model.Id == message.Id);
            if (recipe != null)
            {
                RecipeDetailViewModels.Remove(recipe);
            }
        }

        private void OnIngredientDeleted(DeleteMessage<IngredientWrapper> message)
        {
            var ingredient = IngredientDetailViewModels.SingleOrDefault(i => i.Model.Id == message.Id);
            if (ingredient != null)
            {
                IngredientDetailViewModels.Remove(ingredient);
            }
        }

        private void SelectRecipe(Guid id)
        {
            var recipeDetailViewModel =
                RecipeDetailViewModels.SingleOrDefault(vm => vm.Model.Id == id);
            if (recipeDetailViewModel == null)
            {
                recipeDetailViewModel = _recipeDetailViewModelFactory.Create();
                RecipeDetailViewModels.Add(recipeDetailViewModel);
                recipeDetailViewModel.Load(id);
            }

            SelectedRecipeDetailViewModel = recipeDetailViewModel;
        }

        private void SelectIngredient(Guid id)
        {
            var ingredientDetailViewModel =
                IngredientDetailViewModels.SingleOrDefault(vm => vm.Model.Id == id);
            if (ingredientDetailViewModel == null)
            {
                ingredientDetailViewModel = _ingredientDetailViewModelFactory.Create();
                IngredientDetailViewModels.Add(ingredientDetailViewModel);
                ingredientDetailViewModel.Load(id);
            }

            SelectedIngredientDetailViewModel = ingredientDetailViewModel;
        }

        private void OnCloseRecipeDetailTabExecute(object parameter)
        {
            if (parameter is IRecipeDetailViewModel recipeDetailViewModel)
            {
                // TODO: Check if the Detail has changes and ask user to cancel
                RecipeDetailViewModels.Remove(recipeDetailViewModel);
            }
        }
        private void OnCloseIngredientDetailTabExecute(object parameter)
        {
            if (parameter is IIngredientDetailViewModel ingredientDetailViewModel)
            {
                // TODO: Check if the Detail has changes and ask user to cancel
                IngredientDetailViewModels.Remove(ingredientDetailViewModel);
            }
        }
    }
}