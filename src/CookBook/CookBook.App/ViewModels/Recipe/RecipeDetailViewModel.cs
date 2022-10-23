using CommunityToolkit.Mvvm.Input;
using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;

namespace CookBook.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class RecipeDetailViewModel : ViewModelBase
{
    private readonly IFacade<RecipeEntity, RecipeListModel, RecipeDetailModel, RecipeEntityMapper> recipeFacade;
        
    public Guid Id { get; set; }
    public RecipeDetailModel Recipe { get; set; }

    public RecipeDetailViewModel(IFacade<RecipeEntity, RecipeListModel, RecipeDetailModel, RecipeEntityMapper> recipeFacade)
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
