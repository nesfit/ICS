using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

public partial class RecipeListViewModel : ViewModelBase, IRecipient<RecipeEditMessage>, IRecipient<RecipeDeleteMessage>
{
    private readonly IRecipeFacade recipeFacade;
    private readonly INavigationService navigationService;

    public IEnumerable<RecipeListModel> Recipes { get; set; } = null!;

    public RecipeListViewModel(
        IRecipeFacade recipeFacade,
        INavigationService navigationService,
        IMessengerService messengerService)
        : base(messengerService)
    {
        this.recipeFacade = recipeFacade;
        this.navigationService = navigationService;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Recipes = await recipeFacade.GetAsync();
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
        => await navigationService.GoToAsync<RecipeDetailViewModel>(
            new Dictionary<string, object?> { [nameof(RecipeDetailViewModel.Id)] = id });

    [RelayCommand]
    private async Task GoToCreateAsync()
    {
        await navigationService.GoToAsync("/edit");
    }

    public async void Receive(RecipeEditMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(RecipeDeleteMessage message)
    {
        await LoadDataAsync();
    }
}