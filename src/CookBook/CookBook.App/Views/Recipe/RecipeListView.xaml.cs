using CookBook.App.ViewModels;

namespace CookBook.App.Views.Recipe;

public partial class RecipeListView : ContentPageBase
{
	public RecipeListView(RecipeListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}
