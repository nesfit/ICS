using System;

namespace CookBook.App.ViewModels
{
    public interface IIngredientAmountDetailViewModel : IViewModel
    {
        Guid RecipeId { get; set; }
    }
}