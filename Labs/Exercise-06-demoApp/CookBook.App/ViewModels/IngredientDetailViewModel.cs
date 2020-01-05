using System;
using System.Windows;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Services.MessageDialog;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class IngredientDetailViewModel : ViewModelBase, IIngredientDetailViewModel
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMediator _mediator;
        private readonly IMessageDialogService _messageDialogService;

        public IngredientDetailViewModel(
            IIngredientRepository ingredientRepository,
            IMessageDialogService messageDialogService,
            IMediator mediator)
        {
            this._ingredientRepository = ingredientRepository;
            this._messageDialogService = messageDialogService;
            this._mediator = mediator;

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);

            mediator.Register<IngredientSelectedMessage>(IngredientSelected);
            mediator.Register<IngredientNewMessage>(IngredientNew);
        }

        public IngredientDetailModel Model { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        private void IngredientNew(IngredientNewMessage ingredientNewMessage)
        {
            Model = new IngredientDetailModel();
        }

        private void IngredientSelected(IngredientSelectedMessage ingredientSelectedMessage)
        {
            Model = _ingredientRepository.GetById(ingredientSelectedMessage.Id);
        }

        public void Save()
        {
            Model = _ingredientRepository.InsertOrUpdate(Model);

            _mediator.Send(new IngredientUpdatedMessage {Id = Model.Id});
            Model = null;
        }

        private bool CanSave() =>
            Model != null
            && !string.IsNullOrWhiteSpace(Model.Name)
            && !string.IsNullOrWhiteSpace(Model.Description);

        public void Delete()
        {
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
                    _ingredientRepository.Delete(Model.Id);
                }
                catch
                {
                  var _=  _messageDialogService.Show(
                      $"Deleting of {Model?.Name} failed!", 
                      "Deleting failed", 
                      MessageDialogButtonConfiguration.OK,
                      MessageDialogResult.OK);
                }

                _mediator.Send(new IngredientDeletedMessage {Id = Model.Id});
            }

            Model = null;
        }
    }
}