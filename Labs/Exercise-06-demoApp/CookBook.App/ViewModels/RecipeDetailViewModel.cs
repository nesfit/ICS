using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Services.MessageDialog;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class RecipeDetailViewModel : ViewModelBase, IRecipeDetailViewModel
    {
        private readonly IMediator mediator;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IRecipeRepository recipesRepository;

        public RecipeDetailViewModel(IRecipeRepository recipesRepository, 
            IMessageDialogService messageDialogService, 
            IMediator mediator, 
            IIngredientAmountDetailViewModel ingredientAmountDetailViewModel)
        {
            this.recipesRepository = recipesRepository;
            this._messageDialogService = messageDialogService;
            this.mediator = mediator;
            IngredientAmountDetailViewModel = ingredientAmountDetailViewModel;

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);
            IngredientSelectedCommand = new RelayCommand<IngredientAmountDetailModel>(IngredientAmountSelected);

            mediator.Register<RecipeSelectedMessage>(RecipeSelected);
            mediator.Register<RecipeNewMessage>(RecipeNew);
            mediator.Register<IngredientAmountNewMessage>(NewIngredientAmount);
            mediator.Register<IngredientAmountDeleteMessage>(DeleteIngredientAmount);
        }

        public RelayCommand DeleteCommand { get; }

        public RelayCommand SaveCommand { get; }

        public RecipeDetailModel Model { get; set; }

        public ObservableCollection<IngredientAmountDetailModel> Ingredients { get; set; } =
            new ObservableCollection<IngredientAmountDetailModel>();

        public ICommand IngredientSelectedCommand { get; }

        public IIngredientAmountDetailViewModel IngredientAmountDetailViewModel { get; }

        private void IngredientAmountSelected(IngredientAmountDetailModel ingredientAmountDetailModel) => mediator.Send(new IngredientAmountSelectedMessage {IngredientAmountDetailModel = ingredientAmountDetailModel});

        private void DeleteIngredientAmount(IngredientAmountDeleteMessage ingredientAmountDeleteMessage)
        {
            Model.Ingredients.Remove(ingredientAmountDeleteMessage.Model);
            Ingredients.Remove(ingredientAmountDeleteMessage.Model);
        }

        private void NewIngredientAmount(IngredientAmountNewMessage ingredientAmountNewMessage)
        {
            Model.Ingredients.Add(ingredientAmountNewMessage.Model);
            Ingredients.Add(ingredientAmountNewMessage.Model);
        }

        private void Delete(object obj)
        {
            if (Model.Id != Guid.Empty)
            {
                var delete = _messageDialogService.Show(
                    $"Delete",
                    $"Do you want to delete {Model?.Name}?.",
                    MessageDialogButtonConfiguration.YesNo,
                    MessageDialogResult.No);

                if(delete == MessageDialogResult.No) return;

                try
                {
                    recipesRepository.Delete(Model.Id);
                }
                catch
                {
                    var _ = _messageDialogService.Show(
                        $"Deleting of {Model?.Name} failed!", 
                        "Deleting failed", 
                        MessageDialogButtonConfiguration.OK,
                        MessageDialogResult.OK);
                }

                mediator.Send(new RecipeDeletedMessage {Id = Model.Id});
            }

            Model = null;
        }

        private bool CanSave() =>
            Model != null
            && !string.IsNullOrWhiteSpace(Model.Name)
            && !string.IsNullOrWhiteSpace(Model.Description)
            && Model.Duration != default;

        private void Save()
        {
            Model = recipesRepository.InsertOrUpdate(Model);
            mediator.Send(new RecipeUpdatedMessage {Id = Model.Id});

            Model = null;
            Ingredients = null;
        }

        private void RecipeNew(RecipeNewMessage recipeNewMessage)
        {
            Model = new RecipeDetailModel();
            Ingredients = new ObservableCollection<IngredientAmountDetailModel>();
        }

        private void RecipeSelected(RecipeSelectedMessage recipeSelectedMessage)
        {
            Model = recipesRepository.GetById(recipeSelectedMessage.Id);
            Ingredients = new ObservableCollection<IngredientAmountDetailModel>(Model.Ingredients);
        }
    }
}