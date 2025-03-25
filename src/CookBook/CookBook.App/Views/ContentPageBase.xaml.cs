using CookBook.App.ViewModels;

namespace CookBook.App.Views;

public partial class ContentPageBase
{
    protected ViewModelBase ViewModel { get; }

    public ContentPageBase(ViewModelBase viewModel)
	{
		InitializeComponent();

        BindingContext = ViewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        await ViewModel.OnAppearingAsync();
    }
}
