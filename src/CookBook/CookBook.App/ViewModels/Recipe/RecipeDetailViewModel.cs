using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecipeDetailViewModel : ViewModelBase, IRecipient<RecipeEditMessage>, IRecipient<RecipeIngredientAddMessage>, IRecipient<RecipeIngredientDeleteMessage>
{
    private readonly IRecipeFacade recipeFacade;
    private readonly INavigationService navigationService;

    public Guid Id { get; set; }
    public RecipeDetailModel? Recipe { get; set; }

    public RecipeDetailViewModel(
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

        Recipe = await recipeFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Recipe is not null)
        {
            await recipeFacade.DeleteAsync(Recipe.Id);

            messengerService.Send(new RecipeDeleteMessage());

            navigationService.SendBackButtonPressed();
        }
    }


    [RelayCommand]
    private async Task GoToEditAsync()
    {
        if (Recipe is not null)
        {
            await navigationService.GoToAsync("/edit",
                new Dictionary<string, object?> { [nameof(RecipeEditViewModel.Recipe)] = Recipe with { } });
        }
    }

    public async void Receive(RecipeEditMessage message)
    {
        if (message.RecipeId == Recipe?.Id)
        {
            await LoadDataAsync();
        }
    }

    public async void Receive(RecipeIngredientAddMessage message)
    {
        await LoadDataAsync();
    }

    public async void Receive(RecipeIngredientDeleteMessage message)
    {
        await LoadDataAsync();
    }
}
