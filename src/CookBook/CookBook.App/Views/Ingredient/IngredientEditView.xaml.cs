using CookBook.App.ViewModels;

namespace CookBook.App.Views.Ingredient;

public partial class IngredientEditView
{
	public IngredientEditView(IngredientEditViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}