using CookBook.App.ViewModels;

namespace CookBook.App.Views;

public partial class ContentPageBase : ContentPage
{
    protected IViewModel viewModel { get; }

    public ContentPageBase(IViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = this.viewModel = viewModel;
    }
}