using System;
using System.Windows.Input;
using CookBook.App.Commands;
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
        private IngredientAmountDetailModel _model;

        public IngredientAmountDetailViewModel(
            IIngredientRepository ingredientRepository,
            IMediator mediator)
        {
            this._ingredientRepository = ingredientRepository;
            this._mediator = mediator;
            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete);
            IngredientNewCommand = new RelayCommand(IngredientNew);

            mediator.Register<IngredientSelectedMessage>(IngredientSelected);
            mediator.Register<IngredientAmountSelectedMessage>(IngredientAmountSelected);
        }

        public ICommand IngredientNewCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public IngredientAmountDetailModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private void IngredientAmountSelected(IngredientAmountSelectedMessage ingredientAmountSelectedMessage) => Model = ingredientAmountSelectedMessage.IngredientAmountDetailModel;

        private void IngredientSelected(IngredientSelectedMessage ingredientSelectedMessage)
        {
            var ingredientDetail = _ingredientRepository.GetById(ingredientSelectedMessage.Id);
            Model = new IngredientAmountDetailModel
            {
                IngredientId = ingredientDetail.Id,
                IngredientName = ingredientDetail.Name,
                IngredientDescription = ingredientDetail.Description
            };
        }

        private void IngredientNew()
        {
            _mediator.Send(new IngredientNewMessage());
            Model = null;
        }

        private void Delete()
        {
            _mediator.Send(new IngredientAmountDeleteMessage {Model = Model});

            Model = null;
        }


        private bool CanSave() =>
            Model != null
            && !string.IsNullOrWhiteSpace(Model.IngredientName)
            && !string.IsNullOrWhiteSpace(Model.IngredientDescription)
            && Model.Amount != default;

        private void Save()
        {
            _mediator.Send(new IngredientAmountNewMessage {Model = Model});

            Model = null;
        }
    }
}