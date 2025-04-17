﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Messages;
using CookBook.App.Resources.Texts;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class IngredientDetailViewModel(
    IIngredientFacade ingredientFacade,
    INavigationService navigationService,
    IMessengerService messengerService,
    IAlertService alertService)
    : ViewModelBase(messengerService), IRecipient<IngredientEditMessage>
{
    public Guid Id { get; set; }

    [ObservableProperty]
    public partial IngredientDetailModel? Ingredient { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Ingredient = await ingredientFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (Ingredient is not null)
        {
            try
            {
                await ingredientFacade.DeleteAsync(Ingredient.Id);
                MessengerService.Send(new IngredientDeleteMessage());
                navigationService.SendBackButtonPressed();
            }
            catch (InvalidOperationException)
            {
                await alertService.DisplayAsync(IngredientDetailViewModelTexts.DeleteError_Alert_Title, IngredientDetailViewModelTexts.DeleteError_Alert_Message);
            }
        }
    }

    [RelayCommand]
    private async Task GoToEditAsync()
    {
        if(Ingredient?.Id is not null)
        {
            await navigationService.GoToAsync(NavigationService.IngredientEditRouteRelative,
                new Dictionary<string, object?> { [nameof(IngredientEditViewModel.Id)] = Ingredient.Id });
        }
    }

    public void Receive(IngredientEditMessage message)
    {
        if (message.IngredientId == Ingredient?.Id)
        {
            ForceDataRefreshOnNextAppearing();
        }
    }
}
