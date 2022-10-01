using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Recipe), nameof(Recipe))]
public partial class RecipeEditViewModel : ViewModelBase
{
    private readonly RecipeFacade recipeFacade;

    public RecipeDetailModel Recipe { get; set; } = RecipeDetailModel.Empty;

    public RecipeEditViewModel(RecipeFacade recipeFacade)
    {
        this.recipeFacade = recipeFacade;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        await recipeFacade.SaveAsync(Recipe);

        Shell.Current.SendBackButtonPressed();
    }
}