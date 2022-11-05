using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecipeDetailViewModel : ViewModelBase
{
    private readonly IRecipeFacade recipeFacade;
    private readonly INavigationService navigationService;

    public Guid Id { get; set; }
    public RecipeDetailModel? Recipe { get; set; }

    public RecipeDetailViewModel(
        IRecipeFacade recipeFacade,
        INavigationService navigationService)
    {
        this.recipeFacade = recipeFacade;
        this.navigationService = navigationService;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Recipe = await recipeFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task GoToEditAsync()
    {
        await navigationService.GoToAsync("/edit",
            new Dictionary<string, object?> { [nameof(RecipeEditViewModel.Recipe)] = Recipe });
    }
}
