using System;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Services.MessageDialog;
using CookBook.App.Wrappers;
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
            _ingredientRepository = ingredientRepository;
            _messageDialogService = messageDialogService;
            _mediator = mediator;

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);
        }

        public IngredientWrapper Model { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public void Load(Guid id)
        {
            Model = _ingredientRepository.GetById(id) ?? new IngredientDetailModel();
        }

        public void Save()
        {
            Model = _ingredientRepository.InsertOrUpdate(Model.Model);

            _mediator.Send(new UpdateMessage<IngredientWrapper> {Model = Model});
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

                _mediator.Send(new DeleteMessage<IngredientWrapper>
                {
                    Model = Model
                });
            }
        }
    }
}