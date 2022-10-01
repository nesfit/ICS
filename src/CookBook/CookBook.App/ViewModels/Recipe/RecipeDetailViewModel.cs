using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecipeDetailViewModel : ViewModelBase
{
    private readonly RecipeFacade recipeFacade;
        
    public Guid Id { get; set; }
    public RecipeDetailModel Recipe { get; set; }

    public RecipeDetailViewModel(RecipeFacade recipeFacade)
    {
        this.recipeFacade = recipeFacade;
    }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Recipe = await recipeFacade.GetAsync(Id);
    }

    [RelayCommand]
    private async Task GoToEditAsync()
    {
        await Shell.Current.GoToAsync("/edit",
            new Dictionary<string, object> { [nameof(RecipeEditViewModel.Recipe)] = Recipe });
    }
}
