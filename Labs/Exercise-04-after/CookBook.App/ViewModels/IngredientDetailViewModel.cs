using System;
using System.Windows;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Services;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class IngredientDetailViewModel : ViewModelBase
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMessageBoxService messageBoxService;
        private readonly IMediator mediator;

        public IngredientDetailModel Model { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public IngredientDetailViewModel(
            IIngredientRepository ingredientRepository,
            IMessageBoxService messageBoxService,
            IMediator mediator)
        {
            this.ingredientRepository = ingredientRepository;
            this.messageBoxService = messageBoxService;
            this.mediator = mediator;

            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);

            mediator.Register<IngredientSelectedMessage>(IngredientSelected);
            mediator.Register<IngredientNewMessage>(IngredientNew);
        }



        private void IngredientNew(IngredientNewMessage ingredientNewMessage)
        {
            Model = new IngredientDetailModel();
        }

        private void IngredientSelected(IngredientSelectedMessage ingredientSelectedMessage)
        {
            Model = ingredientRepository.GetById(ingredientSelectedMessage.Id);
        }

        public void Save()
        {
            if (Model.Id == Guid.Empty)
            {
                Model = ingredientRepository.Create(Model);
                mediator.Send(new IngredientAddedMessage { Id = Model.Id });
            }
            else
            {
                ingredientRepository.Update(Model);
                mediator.Send(new IngredientUpdatedMessage { Id = Model.Id });
            }
            Model = null;
        }

        private bool CanSave()
        {
            return Model != null
                   && !string.IsNullOrWhiteSpace(Model.Name)
                   && !string.IsNullOrWhiteSpace(Model.Description);
        }

        public void Delete()
        {
            if (Model.Id != Guid.Empty)
            {
                try
                {
                    ingredientRepository.Delete(Model.Id);
                }
                catch
                {
                    messageBoxService.Show($"Deleting of {Model?.Name} failed!", "Deleting failed", MessageBoxButton.OK);
                }

                mediator.Send(new IngredientDeletedMessage { Id = Model.Id });
            }
            Model = null;
        }
    }
}