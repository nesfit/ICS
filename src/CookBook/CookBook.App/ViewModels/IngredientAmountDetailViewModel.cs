using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.App.Wrappers;
using CookBook.BL.Models;
using System;
using System.Windows.Input;
using CookBook.App.Commands;
using CookBook.BL.Facades;

namespace CookBook.App.ViewModels
{
    public class IngredientAmountDetailViewModel : ViewModelBase, IIngredientAmountDetailViewModel
    {
        private readonly IngredientFacade _ingredientFacade;
        private readonly IMediator _mediator;

        public IngredientAmountDetailViewModel(
            IngredientFacade ingredientFacade,
            IMediator mediator)
        {
            _ingredientFacade = ingredientFacade;
            _mediator = mediator;
            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);
            IngredientNewCommand = new RelayCommand(IngredientNew);

            mediator.Register<SelectedMessage<IngredientWrapper>>(IngredientSelected);
            mediator.Register<SelectedMessage<IngredientAmountWrapper>>(IngredientAmountSelected);
        }

        public ICommand IngredientNewCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public IngredientAmountWrapper? Model { get; set; }

        public ICommand SaveCommand { get; }

        public Guid RecipeId { get; set; }

        private void IngredientAmountSelected(SelectedMessage<IngredientAmountWrapper> message)
        {
            if (message.TargetId != RecipeId) return;

            Model = message.Model;
        }

        private void IngredientSelected(SelectedMessage<IngredientWrapper> message)
        {
            var ingredientDetail = _ingredientFacade.GetAsync(message.Id).GetAwaiter().GetResult();
            Model = new IngredientAmountDetailModel(
                ingredientDetail?.Id ?? Guid.Empty,
                ingredientDetail?.Name ?? string.Empty,
                ingredientDetail?.Description ?? string.Empty,
                default,
                default
                )
            {
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
            && !Model.Amount.Equals(default);

        private void Save()
        {
            if (Model == null) throw new InvalidOperationException("Null model cannot be saved");

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