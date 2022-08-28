using CookBook.App.ViewModels.Recipe;

namespace CookBook.App.Views.Recipe;

public partial class RecipeListView
{
	public RecipeListView(RecipeListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}