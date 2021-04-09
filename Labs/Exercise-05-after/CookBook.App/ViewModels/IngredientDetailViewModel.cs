using CookBook.App.Commands;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using System;
using System.Windows;
using System.Windows.Input;

namespace CookBook.App.ViewModels
{
    public class IngredientDetailViewModel : ViewModelBase
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IMediator _mediator;

        public IngredientDetailModel Model { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public IngredientDetailViewModel(
            IIngredientRepository ingredientRepository,
            IMessageBoxService messageBoxService,
            IMediator mediator)
        {
            _ingredientRepository = ingredientRepository;
            _messageBoxService = messageBoxService;
            _mediator = mediator;

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);

            _mediator.Register<SelectedMessage>(IngredientSelected);
            _mediator.Register<NewMessage>(IngredientNew);
        }

        private void IngredientNew(NewMessage newMessage)
            => Model = new IngredientDetailModel();

        private void IngredientSelected(SelectedMessage selectedMessage)
            => Model = _ingredientRepository.GetById(selectedMessage.Id);

        public void Save()
        {
            if (Model.Id == Guid.Empty)
            {
                _ingredientRepository.InsertOrUpdate(Model);
                _mediator.Send(new AddedMessage { Id = Model.Id });
            }
            else
            {
                _ingredientRepository.InsertOrUpdate(Model);
                _mediator.Send(new UpdateMessage { Id = Model.Id });
            }

            Model = null;
        }

        private bool CanSave()
            => Model != null
               && !string.IsNullOrWhiteSpace(Model.Name)
               && !string.IsNullOrWhiteSpace(Model.Description);

        public void Delete()
        {
            if (Model.Id != Guid.Empty)
            {
                try
                {
                    _ingredientRepository.Delete(Model.Id);
                }
                catch
                {
                    _messageBoxService.Show($"Deleting of {Model?.Name} failed!", "Deleting failed", MessageBoxButton.OK);
                }

                _mediator.Send(new DeleteMessage { Id = Model.Id });
            }
            Model = null;
        }
    }
}