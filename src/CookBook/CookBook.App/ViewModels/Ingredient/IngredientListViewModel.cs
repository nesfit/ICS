using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

public partial class IngredientListViewModel : ViewModelBase
{
    private readonly IIngredientFacade ingredientFacade;
    private readonly INavigationService navigationService;

    public IEnumerable<IngredientListModel> Ingredients { get; set; } = null!;

    public IngredientListViewModel(
        IIngredientFacade ingredientFacade,
        INavigationService navigationService)
    {
        this.ingredientFacade = ingredientFacade;
        this.navigationService = navigationService;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredients = await ingredientFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        await navigationService.GoToAsync<IngredientDetailViewModel>(
            new Dictionary<string, object?> { [nameof(IngredientDetailViewModel.Id)] = id });
    }
}