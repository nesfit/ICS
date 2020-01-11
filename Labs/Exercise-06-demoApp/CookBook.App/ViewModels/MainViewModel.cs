using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Factories;
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
            IIngredientDetailViewModel ingredientDetailViewModel,
            IRecipeListViewModel recipeListViewModel,
            IRecipeDetailViewModel recipeDetailViewModel,
            IMediator mediator,
            IFactory<IRecipeDetailViewModel> recipeDetailViewModelFactory,
            IFactory<IIngredientDetailViewModel> ingredientDetailViewModelFactory)
        {
            _recipeDetailViewModelFactory = recipeDetailViewModelFactory;
            _ingredientDetailViewModelFactory = ingredientDetailViewModelFactory;
            IngredientListViewModel = ingredientListViewModel;
            IngredientDetailViewModel = ingredientDetailViewModel;
            RecipeListViewModel = recipeListViewModel;
            RecipeDetailViewModel = recipeDetailViewModel;
            
            CloseRecipeDetailTabCommand = new RelayCommand(OnCloseRecipeDetailTabExecute);
            CloseIngredientDetailTabCommand = new RelayCommand(OnCloseIngredientDetailTabExecute);
            
            mediator.Register<RecipeNewMessage>(OnRecipeNewMessage);
            mediator.Register<IngredientNewMessage>(OnIngredientNewMessage);
            mediator.Register<RecipeSelectedMessage>(OnRecipeSelected);
            mediator.Register<IngredientSelectedMessage>(OnIngredientSelected);
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

        private void OnRecipeNewMessage(RecipeNewMessage obj)
        {
            SelectRecipe(Guid.Empty);
        }

        private void OnIngredientNewMessage(IngredientNewMessage obj)
        {
            SelectIngredient(Guid.Empty);
        }

        private void OnRecipeSelected(RecipeSelectedMessage recipeSelectedMessage)
        {
            SelectRecipe(recipeSelectedMessage.Id);
        }

        private void OnIngredientSelected(IngredientSelectedMessage ingredientSelectedMessage)
        {
            SelectIngredient(ingredientSelectedMessage.Id);
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