using CookBook.App.ViewModels;

namespace CookBook.App.Views.Recipe;

public partial class RecipeDetailView : ContentPageBase
{
	public RecipeDetailView(RecipeDetailViewModel viewModel)
        : base(viewModel)
    {
		InitializeComponent();
	}
}
