using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.App.Services.MessageDialog;
using CookBook.App.Wrappers;
using CookBook.BL.Models;
using System;
using System.Threading.Tasks;
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

            SaveCommand = new AsyncRelayCommand(SaveAsync, CanSave);
            DeleteCommand = new AsyncRelayCommand(DeleteAsync);

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

        public async Task LoadAsync(Guid id) => Model = await _recipeFacade.GetAsync(id) ?? RecipeDetailModel.Empty;

        private void DeleteIngredientAmount(DeleteMessage<IngredientAmountWrapper> message)
        {
            if (message.TargetId != Model?.Id || message.Model is null)
            {
                return;
            }

            Model?.Ingredients.Remove(message.Model);
            SelectedIngredientAmount = null;
        }

        private void NewIngredientAmount(NewMessage<IngredientAmountWrapper> message)
        {
            if (message.TargetId != Model?.Id || message.Model is null)
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

        public async Task DeleteAsync()
        {
            if (Model is null)
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
                    await _recipeFacade.DeleteAsync(Model!.Id);
                }
                catch
                {
                    var _ = _messageDialogService.Show(
                        $"Deleting of {Model?.Name} failed!",
                        "Deleting failed",
                        MessageDialogButtonConfiguration.OK,
                        MessageDialogResult.OK);
                }

                _mediator.Send(new DeleteMessage<RecipeWrapper> { Model = Model! });
            }
        }

        private bool CanSave() => Model?.IsValid ?? false;

        public async Task SaveAsync()
        {
            if (Model is null)
            {
                throw new InvalidOperationException("Null model cannot be saved");
            }

            Model = await _recipeFacade.SaveAsync(Model);
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