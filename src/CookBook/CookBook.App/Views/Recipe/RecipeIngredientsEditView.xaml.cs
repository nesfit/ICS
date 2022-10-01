using CookBook.App.ViewModels;

namespace CookBook.App.Views.Recipe;

public partial class RecipeIngredientsEditView
{
    public RecipeIngredientsEditView(RecipeIngredientsEditViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}