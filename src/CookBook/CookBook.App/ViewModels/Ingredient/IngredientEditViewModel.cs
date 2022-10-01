using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Ingredient), nameof(Ingredient))]
public partial class IngredientEditViewModel : ViewModelBase
{
    public IngredientDetailModel Ingredient { get; set; } = IngredientDetailModel.Empty;
}