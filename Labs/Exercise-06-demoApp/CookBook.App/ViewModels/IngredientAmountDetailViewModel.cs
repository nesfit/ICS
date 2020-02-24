using System;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.App.Wrappers;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class IngredientAmountDetailViewModel : ViewModelBase, IIngredientAmountDetailViewModel
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMediator _mediator;

        public IngredientAmountDetailViewModel(
            IIngredientRepository ingredientRepository,
            IMediator mediator)
        {
            _ingredientRepository = ingredientRepository;
            _mediator = mediator;
            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);
            IngredientNewCommand = new RelayCommand(IngredientNew);

            mediator.Register<SelectedMessage<IngredientWrapper>>(IngredientSelected);
            mediator.Register<SelectedMessage<IngredientAmountWrapper>>(IngredientAmountSelected);
        }

        public ICommand IngredientNewCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public IngredientAmountWrapper Model { get; set; }

        public ICommand SaveCommand { get; }

        public Guid RecipeId { get; set; }

        private void IngredientAmountSelected(SelectedMessage<IngredientAmountWrapper> message)
        {
            if (message.TargetId != RecipeId) return;

            Model = message.Model;
        }

        private void IngredientSelected(SelectedMessage<IngredientWrapper> message)
        {
            var ingredientDetail = _ingredientRepository.GetById(message.Id);
            Model = new IngredientAmountDetailModel
            {
                IngredientId = ingredientDetail.Id,
                IngredientName = ingredientDetail.Name,
                IngredientDescription = ingredientDetail.Description
            };
        }

        private void IngredientNew()
        {
            _mediator.Send(new NewMessage<IngredientWrapper>());
            Model = null;
        }

        private void Delete()
        {
            _mediator.Send(new DeleteMessage<IngredientAmountWrapper>
            {
                TargetId = RecipeId,
                Model = Model
            });

            Model = null;
        }


        private bool CanSave() =>
            Model != null
            && !string.IsNullOrWhiteSpace(Model.IngredientName)
            && !string.IsNullOrWhiteSpace(Model.IngredientDescription)
            && Model.Amount != default;

        private void Save()
        {
            if (Model.Id == Guid.Empty)
            {
                _mediator.Send(new NewMessage<IngredientAmountWrapper>
                {
                    TargetId = RecipeId,
                    Model = Model
                });
            }
            else
            {
                _mediator.Send(new UpdateMessage<IngredientAmountWrapper>
                {
                    TargetId = RecipeId,
                    Model = Model
                });
            }

            Model = null;
        }
    }
}