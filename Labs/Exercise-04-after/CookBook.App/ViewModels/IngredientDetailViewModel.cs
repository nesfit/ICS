using System;
using System.Windows;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Models;
using CookBook.BL.Repositories;

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

            _mediator.Register<IngredientSelectedMessage>(IngredientSelected);
            _mediator.Register<IngredientNewMessage>(IngredientNew);
        }



        private void IngredientNew(IngredientNewMessage ingredientNewMessage) 
            => Model = new IngredientDetailModel();

        private void IngredientSelected(IngredientSelectedMessage ingredientSelectedMessage) 
            => Model = _ingredientRepository.GetById(ingredientSelectedMessage.Id);

        public void Save()
        {
            IMessage message = Model.Id == Guid.Empty
                ? new IngredientAddedMessage {Id = Model.Id}
                : new IngredientUpdatedMessage {Id = Model.Id};
            
            _ingredientRepository.InsertOrUpdate(Model);
            _mediator.Send(message);

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

                _mediator.Send(new IngredientDeletedMessage { Id = Model.Id });
            }
            Model = null;
        }
    }
}