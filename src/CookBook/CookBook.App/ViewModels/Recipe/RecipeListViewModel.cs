using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

public partial class RecipeListViewModel : ViewModelBase
{
    private readonly RecipeFacade recipeFacade;
    private readonly IRoutingService routingService;

    public IEnumerable<RecipeListModel> Recipes { get; set; }

    public RecipeListViewModel(
        RecipeFacade recipeFacade,
        IRoutingService routingService)
    {
        this.recipeFacade = recipeFacade;
        this.routingService = routingService;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Recipes = await recipeFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
        =>  await Shell.Current.GoToAsync(routingService.GetRouteByViewModel<RecipeDetailViewModel>(), 
                new Dictionary<string, object> { [nameof(RecipeDetailViewModel.Id)] = id });

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await Shell.Current.GoToAsync("/edit");
    }
}