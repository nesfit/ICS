using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Services.MessageDialog;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class RecipeDetailViewModel : ViewModelBase, IRecipeDetailViewModel
    {
        private readonly IMediator _mediator;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IRecipeRepository _recipesRepository;

        public RecipeDetailViewModel(
            IRecipeRepository recipesRepository,
            IMessageDialogService messageDialogService,
            IMediator mediator,
            IIngredientAmountDetailViewModel ingredientAmountDetailViewModel)
        {
            _recipesRepository = recipesRepository;
            _messageDialogService = messageDialogService;
            _mediator = mediator;
            IngredientAmountDetailViewModel = ingredientAmountDetailViewModel;

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);
            IngredientSelectedCommand = new RelayCommand<IngredientAmountDetailModel>(IngredientAmountSelected);

            mediator.Register<IngredientAmountNewMessage>(NewIngredientAmount);
            mediator.Register<IngredientAmountDeleteMessage>(DeleteIngredientAmount);
        }

        public RelayCommand DeleteCommand { get; }

        public RelayCommand SaveCommand { get; }

        public ObservableCollection<IngredientAmountDetailModel> Ingredients { get; set; } =
            new ObservableCollection<IngredientAmountDetailModel>();

        public ICommand IngredientSelectedCommand { get; }

        public IIngredientAmountDetailViewModel IngredientAmountDetailViewModel { get; }

        public RecipeDetailModel Model { get; set; }


        public void Load(Guid id)
        {
            Model = _recipesRepository.GetById(id) ?? new RecipeDetailModel();
            Ingredients = new ObservableCollection<IngredientAmountDetailModel>(Model?.Ingredients);
            IngredientAmountDetailViewModel.RecipeId = Model.Id;
        }

        private void IngredientAmountSelected(IngredientAmountDetailModel ingredientAmountDetailModel) =>
            _mediator.Send(new IngredientAmountSelectedMessage
                {IngredientAmountDetailModel = ingredientAmountDetailModel});

        private void DeleteIngredientAmount(IngredientAmountDeleteMessage ingredientAmountDeleteMessage)
        {
            Model.Ingredients.Remove(ingredientAmountDeleteMessage.Model);
            Ingredients.Remove(ingredientAmountDeleteMessage.Model);
        }

        private void NewIngredientAmount(IngredientAmountNewMessage ingredientAmountNewMessage)
        {
            if(ingredientAmountNewMessage.RecipeId != Model?.Id) return;

            Model.Ingredients.Add(ingredientAmountNewMessage.Model);
            Ingredients.Add(ingredientAmountNewMessage.Model);
        }

        private void Delete(object obj)
        {
            if (Model.Id != Guid.Empty)
            {
                var delete = _messageDialogService.Show(
                    "Delete",
                    $"Do you want to delete {Model?.Name}?.",
                    MessageDialogButtonConfiguration.YesNo,
                    MessageDialogResult.No);

                if (delete == MessageDialogResult.No) return;

                try
                {
                    _recipesRepository.Delete(Model.Id);
                }
                catch
                {
                    var _ = _messageDialogService.Show(
                        $"Deleting of {Model?.Name} failed!",
                        "Deleting failed",
                        MessageDialogButtonConfiguration.OK,
                        MessageDialogResult.OK);
                }

                _mediator.Send(new RecipeDeletedMessage {Id = Model.Id});
            }
        }

        private bool CanSave() =>
            Model != null
            && !string.IsNullOrWhiteSpace(Model.Name)
            && !string.IsNullOrWhiteSpace(Model.Description)
            && Model.Duration != default;

        private void Save()
        {
            Model = _recipesRepository.InsertOrUpdate(Model);
            _mediator.Send(new RecipeUpdatedMessage {Id = Model.Id});
        }
    }
}