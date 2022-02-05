using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.App.Services.MessageDialog;
using CookBook.App.Wrappers;
using CookBook.BL.Models;
using System;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.BL.Facades;
using CookBook.Common.Enums;

namespace CookBook.App.ViewModels
{
    public class RecipeDetailViewModel : ViewModelBase, IRecipeDetailViewModel
    {
        private readonly IMediator _mediator;
        private readonly RecipeFacade _recipeFacade;
        private readonly IMessageDialogService _messageDialogService;
        private RecipeWrapper? _model = RecipeDetailModel.Empty;
        private IngredientAmountWrapper? _selectedIngredientAmount;

        public RecipeDetailViewModel(
            RecipeFacade recipeFacade,
            IMessageDialogService messageDialogService,
            IMediator mediator,
            IIngredientAmountDetailViewModel ingredientAmountDetailViewModel)
        {
            _recipeFacade = recipeFacade;
            _messageDialogService = messageDialogService;
            _mediator = mediator;
            IngredientAmountDetailViewModel = ingredientAmountDetailViewModel;

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);

            mediator.Register<NewMessage<IngredientAmountWrapper>>(NewIngredientAmount);
            mediator.Register<UpdateMessage<IngredientAmountWrapper>>(UpdateIngredientAmount);
            mediator.Register<DeleteMessage<IngredientAmountWrapper>>(DeleteIngredientAmount);
        }

        public ICommand DeleteCommand { get; }

        public ICommand SaveCommand { get; }

        public IIngredientAmountDetailViewModel IngredientAmountDetailViewModel { get; }

        public IngredientAmountWrapper? SelectedIngredientAmount
        {
            get => _selectedIngredientAmount;
            set
            {
                _selectedIngredientAmount = value;
                OnPropertyChanged();
                _mediator.Send(new SelectedMessage<IngredientAmountWrapper>
                {
                    TargetId = Model?.Id ?? Guid.Empty,
                    Model = _selectedIngredientAmount
                });
            }
        }

        public RecipeWrapper? Model
        {
            get => _model;
            set
            {
                _model = value;
                IngredientAmountDetailViewModel.RecipeId = value?.Id ?? Guid.Empty;
            }
        }

        public void Load(Guid id) => Model = _recipeFacade.GetAsync(id).GetAwaiter().GetResult() ?? RecipeDetailModel.Empty;

        private void DeleteIngredientAmount(DeleteMessage<IngredientAmountWrapper> message)
        {
            if (Model != null && message.TargetId != Model?.Id)
            {
                return;
            }

            Model?.Ingredients.Remove(message.Model);
            SelectedIngredientAmount = null;
        }

        private void NewIngredientAmount(NewMessage<IngredientAmountWrapper> message)
        {
            if (Model != null && message.TargetId != Model.Id)
            {
                return;
            }
            
            Model?.Ingredients.Add(message.Model);
        }

        private void UpdateIngredientAmount(UpdateMessage<IngredientAmountWrapper> message)
        {
            if (message.TargetId != Model?.Id)
            {
                return;
            }

            SelectedIngredientAmount = null;
        }

        private void Delete()
        {
            if (Model == null)
            {
                throw new InvalidOperationException("Null model cannot be deleted");
            }

            if (Model.Id != Guid.Empty)
            {
                var delete = _messageDialogService.Show(
                    "Delete",
                    $"Do you want to delete {Model?.Name}?.",
                    MessageDialogButtonConfiguration.YesNo,
                    MessageDialogResult.No);

                if (delete == MessageDialogResult.No)
                {
                    return;
                }

                try
                {
                    _recipeFacade.DeleteAsync(Model.Id).GetAwaiter().GetResult();
                }
                catch
                {
                    var _ = _messageDialogService.Show(
                        $"Deleting of {Model?.Name} failed!",
                        "Deleting failed",
                        MessageDialogButtonConfiguration.OK,
                        MessageDialogResult.OK);
                }

                _mediator.Send(new DeleteMessage<RecipeWrapper> { Model = Model });
            }
        }

        private bool CanSave() =>
            Model != null
            && !string.IsNullOrWhiteSpace(Model.Name)
            && !string.IsNullOrWhiteSpace(Model.Description)
            && Model.Duration != default;

        private void Save()
        {
            if (Model == null)
            {
                throw new InvalidOperationException("Null model cannot be saved");
            }

            Model = _recipeFacade.SaveAsync(Model).GetAwaiter().GetResult();
            _mediator.Send(new UpdateMessage<RecipeWrapper> { Model = Model });
        }

        public override void LoadInDesignMode()
        {
            base.LoadInDesignMode();
            Model = new RecipeWrapper(new RecipeDetailModel(
                Name: "Spaghetti",
                Description: "Spaghetti description",
                Duration: new TimeSpan(0, 30, 0),
                FoodType.MainDish
                )
            {
                ImageUrl = "https://cleanfoodcrush.com/wp-content/uploads/2019/01/CleanFoodCrush-Super-Easy-Beef-Stir-Fry-Recipe.jpg"
            });
        }
    }
}