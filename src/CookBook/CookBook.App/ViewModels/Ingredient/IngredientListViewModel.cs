﻿using CommunityToolkit.Mvvm.Input;
using CookBook.App.Services;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

public partial class IngredientListViewModel : ViewModelBase
{
    private readonly IngredientFacade ingredientFacade;
    private readonly IRoutingService routingService;

    public IEnumerable<IngredientListModel> Ingredients { get; set; }

    public IngredientListViewModel(
        IngredientFacade ingredientFacade,
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
    }

    [RelayCommand]
    private async Task GoToDetailAsync(Guid id)
    {
        var route = routingService.GetRouteByViewModel<IngredientDetailViewModel>();
        await Shell.Current.GoToAsync(route,
            new Dictionary<string, object> { [nameof(IngredientDetailViewModel.Id)] = id });
    }
}