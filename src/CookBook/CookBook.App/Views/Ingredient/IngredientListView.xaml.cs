using CookBook.App.ViewModels;

namespace CookBook.App.Views.Ingredient;

public partial class IngredientListView
{
	public IngredientListView(IngredientListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}