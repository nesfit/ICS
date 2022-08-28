using CookBook.App.ViewModels;

namespace CookBook.App.Views.Ingredient;

public partial class IngredientDetailView
{
	public IngredientDetailView(IngredientDetailViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}