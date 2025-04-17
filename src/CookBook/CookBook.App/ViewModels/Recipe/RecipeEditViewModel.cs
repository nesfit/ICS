using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Messages;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecipeEditViewModel(
    IRecipeFacade recipeFacade,
    INavigationService navigationService,
    IMessengerService messengerService)
    : ViewModelBase(messengerService), IRecipient<RecipeIngredientEditMessage>, IRecipient<RecipeIngredientAddMessage>,
        IRecipient<RecipeIngredientDeleteMessage>
{
    public Guid Id { get; set; }

    [ObservableProperty]
    public partial RecipeDetailModel Recipe { get; set; } = RecipeDetailModel.Empty;

    public List<FoodType> FoodTypes { get; set; } = [.. (FoodType[])Enum.GetValues(typeof(FoodType))];

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Recipe = await recipeFacade.GetAsync(Id)
                 ?? RecipeDetailModel.Empty;
    }

    [RelayCommand]
    private async Task GoToRecipeIngredientEditAsync()
    {
        await navigationService.GoToAsync(NavigationService.RecipeIngredientsEditRouteRelative,
            new Dictionary<string, object?>
            {
                [nameof(RecipeIngredientsEditViewModel.Id)] = Recipe.Id
                });
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await recipeFacade.SaveAsync(RecipeDetailModel.Copy(Recipe, ingredients: []));

        MessengerService.Send(new RecipeEditMessage { RecipeId = Recipe.Id});

        navigationService.SendBackButtonPressed();
    }

    public void Receive(RecipeIngredientEditMessage message)
    {
        ForceDataRefreshOnNextAppearing();
    }

    public void Receive(RecipeIngredientAddMessage message)
    {
        ForceDataRefreshOnNextAppearing();
    }

    public void Receive(RecipeIngredientDeleteMessage message)
    {
        ForceDataRefreshOnNextAppearing();
    }
}
