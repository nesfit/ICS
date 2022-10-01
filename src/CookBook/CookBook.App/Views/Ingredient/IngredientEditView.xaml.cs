using CookBook.App.ViewModels;

namespace CookBook.App.Views.Ingredient;

public partial class IngredientEditView
{
	public IngredientEditView(IngredientListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}