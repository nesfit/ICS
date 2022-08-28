using CookBook.App.ViewModels;

namespace CookBook.App.Views.Recipe;

public partial class RecipeListView
{
	public RecipeListView(RecipeListViewModel viewModel)
		: base(viewModel)
	{
		InitializeComponent();
	}
}