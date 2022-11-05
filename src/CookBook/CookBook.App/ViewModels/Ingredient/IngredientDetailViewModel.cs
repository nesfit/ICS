using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class IngredientDetailViewModel : ViewModelBase
{
    private readonly IIngredientFacade ingredientFacade;
    private readonly INavigationService navigationService;

    public Guid Id { get; set; }
    public IngredientDetailModel? Ingredient { get; private set; }

    public IngredientDetailViewModel(
        IIngredientFacade ingredientFacade,
        INavigationService navigationService)
    {
        this.ingredientFacade = ingredientFacade;
        this.navigationService = navigationService;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredient = await ingredientFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        await ingredientFacade.DeleteAsync(Id);
        navigationService.SendBackButtonPressed();
    }

    [RelayCommand]
    private async Task GoToEditAsync()
    {
        await navigationService.GoToAsync("/edit",
            new Dictionary<string, object?> { [nameof(IngredientEditViewModel.Ingredient)] = Ingredient });
    }
}