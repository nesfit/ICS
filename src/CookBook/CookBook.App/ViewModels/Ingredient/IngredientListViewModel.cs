using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;

namespace CookBook.App.ViewModels;

public partial class IngredientListViewModel : ViewModelBase
{
    private readonly IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade;
    private readonly IRoutingService routingService;

    public IEnumerable<IngredientListModel> Ingredients { get; set; }

    public IngredientListViewModel(
        IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper> ingredientFacade,
        IRoutingService routingService)
    {
        this.ingredientFacade = ingredientFacade;
        this.routingService = routingService;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredients = await ingredientFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await Shell.Current.GoToAsync("/edit");
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        var route = routingService.GetRouteByViewModel<IngredientDetailViewModel>();
        await Shell.Current.GoToAsync(route,
            new Dictionary<string, object> { [nameof(IngredientDetailViewModel.Id)] = id });
    }
}