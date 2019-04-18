using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Services;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class RecipeDetailViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly IMessageBoxService messageBoxService;
        private readonly IRecipeRepository recipesRepository;

        public RecipeDetailViewModel(IRecipeRepository recipesRepository, IMessageBoxService messageBoxService, IMediator mediator)
        {
            this.recipesRepository = recipesRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

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

        private void Delete(Object obj)
        {
            if (Model.Id != Guid.Empty)
            {
                try
                {
                    recipesRepository.Delete(Model.Id);
                }
                catch
                {
                    messageBoxService.Show($"Deleting of {Model?.Name} failed!", "Deleting failed", MessageBoxButton.OK);
                }

                mediator.Send(new RecipeDeletedMessage {Id = Model.Id});
            }

            Model = null;
        }

        private Boolean CanSave() =>
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