using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Recipe), nameof(Recipe))]
public partial class RecipeEditViewModel : ViewModelBase, IRecipient<RecipeIngredientEditMessage>, IRecipient<RecipeIngredientAddMessage>, IRecipient<RecipeIngredientDeleteMessage>
{
    private readonly IRecipeFacade _recipeFacade;
    private readonly INavigationService _navigationService;

    public RecipeDetailModel Recipe { get; set; } = RecipeDetailModel.Empty;

    public List<FoodType> FoodTypes { get; set; }

    public RecipeEditViewModel(
        IRecipeFacade recipeFacade,
        INavigationService navigationService,
        IMessengerService messengerService) 
        : base(messengerService)
    {
        this._recipeFacade = recipeFacade;
        this._navigationService = navigationService;

        FoodTypes = new List<FoodType>((FoodType[])Enum.GetValues(typeof(FoodType)));
    }

    [RelayCommand]
    private async Task GoToRecipeIngredientEditAsync()
    {
        await _navigationService.GoToAsync("/ingredients",
            new Dictionary<string, object?> { [nameof(RecipeIngredientsEditViewModel.Recipe)] = Recipe });
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await _recipeFacade.SaveAsync(Recipe with{ Ingredients = default! });

        MessengerService.Send(new RecipeEditMessage { RecipeId = Recipe.Id});

        _navigationService.SendBackButtonPressed();
    }

    public async void Receive(RecipeIngredientEditMessage message)
    {
        await ReloadDataAsync();
    }

    public async void Receive(RecipeIngredientAddMessage message)
    {
        await ReloadDataAsync();
    }

    public async void Receive(RecipeIngredientDeleteMessage message)
    {
        await ReloadDataAsync();
    }

    private async Task ReloadDataAsync()
    {
        Recipe = await _recipeFacade.GetAsync(Recipe.Id)
                 ?? RecipeDetailModel.Empty;
    }
}
