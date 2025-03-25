using CookBook.App.ViewModels;

namespace CookBook.App.Views.Ingredient;

public partial class IngredientDetailView : ContentPageBase
{
	public IngredientDetailView(IngredientDetailViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}
