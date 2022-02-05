using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.App.Services.MessageDialog;
using CookBook.App.Wrappers;
using CookBook.BL.Models;
using System;
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

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);
        }

        public IngredientWrapper? Model { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public void Load(Guid id)
        {
            Model = _ingredientFacade.GetAsync(id).GetAwaiter().GetResult() ??  IngredientDetailModel.Empty;
        }

        public void Save()
        {
            if (Model == null)
            {
                throw new InvalidOperationException("Null model cannot be saved");
            }

            Model = _ingredientFacade.SaveAsync(Model.Model).GetAwaiter().GetResult();
            _mediator.Send(new UpdateMessage<IngredientWrapper> { Model = Model });
        }

        private bool CanSave() =>
            Model != null
            && !string.IsNullOrWhiteSpace(Model.Name)
            && !string.IsNullOrWhiteSpace(Model.Description);

        public void Delete()
        {
            if (Model == null)
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
                    _ingredientFacade.DeleteAsync(Model.Id).GetAwaiter().GetResult();
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
                Name: "Voda",
                Description: "Popis vody")
            {
                ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
            });
        }
    }
}