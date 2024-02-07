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

namespace CookBook.App.ViewModels
{
    public class IngredientDetailViewModel : ViewModelBase, IIngredientDetailViewModel
    {
        private readonly IMediator _mediator;
        private readonly IngredientFacade _ingredientFacade;
        private readonly IMessageDialogService _messageDialogService;

        public IngredientDetailViewModel(
            IngredientFacade ingredientFacade,
            IMessageDialogService messageDialogService,
            IMediator mediator)
        {
            _ingredientFacade = ingredientFacade;
            _messageDialogService = messageDialogService;
            _mediator = mediator;

            SaveCommand = new AsyncRelayCommand(SaveAsync, CanSave);
            DeleteCommand = new AsyncRelayCommand(DeleteAsync);
        }

        public IngredientWrapper? Model { get; private set; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }


        public async Task LoadAsync(Guid id)
        {
            Model = await _ingredientFacade.GetAsync(id) ??  IngredientDetailModel.Empty;
        }

        public async Task SaveAsync()
        {
            if (Model is null)
            {
                throw new InvalidOperationException("Null model cannot be saved");
            }

            Model = await _ingredientFacade.SaveAsync(Model.Model);
            _mediator.Send(new UpdateMessage<IngredientWrapper> { Model = Model });
        }

        private bool CanSave() => Model?.IsValid ?? false;

        public async Task DeleteAsync()
        {
            if (Model is null)
            {
                throw new InvalidOperationException("Null model cannot be deleted");
            }

            if (Model.Id != Guid.Empty)
            {
                var delete = _messageDialogService.Show(
                    $"Delete",
                    $"Do you want to delete {Model?.Name}?.",
                    MessageDialogButtonConfiguration.YesNo,
                    MessageDialogResult.No);

                if (delete == MessageDialogResult.No) return;

                try
                {
                    await _ingredientFacade.DeleteAsync(Model!.Id);
                }
                catch
                {
                    var _ = _messageDialogService.Show(
                        $"Deleting of {Model?.Name} failed!",
                        "Deleting failed",
                        MessageDialogButtonConfiguration.OK,
                        MessageDialogResult.OK);
                }

                _mediator.Send(new DeleteMessage<IngredientWrapper>
                {
                    Model = Model
                });
            }
        }

        public override void LoadInDesignMode()
        {
            base.LoadInDesignMode();
            Model = new IngredientWrapper(new IngredientDetailModel(
                Name: "Water",
                Description: "Water description")
            {
                ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
            });
        }
    }
}