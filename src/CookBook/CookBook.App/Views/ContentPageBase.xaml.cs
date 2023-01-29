using CookBook.App.ViewModels;

namespace CookBook.App.Views;

public partial class ContentPageBase
{
    protected IViewModel viewModel { get; }

    public ContentPageBase(IViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = this.viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        await viewModel.OnAppearingAsync();
    }
}