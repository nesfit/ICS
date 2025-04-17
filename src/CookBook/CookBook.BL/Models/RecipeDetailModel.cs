using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Common.Enums;

namespace CookBook.BL.Models;

public partial class RecipeDetailModel : ModelBase
{
    [ObservableProperty]
    public required partial string Name { get; set; }

    [ObservableProperty]
    public required partial string Description { get; set; }

    [ObservableProperty]
    public required partial TimeSpan Duration { get; set; }

    [ObservableProperty]
    public partial FoodType FoodType { get; set; }

    [ObservableProperty]
    public partial string? ImageUrl { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<IngredientAmountListModel> Ingredients { get; set; } = [];

    public static RecipeDetailModel Empty
        => new()
        {
            Id = Guid.Empty,
            Name = string.Empty,
            Description = string.Empty,
            Duration = TimeSpan.Zero
        };

    public static RecipeDetailModel Copy(RecipeDetailModel model,
        string? name = null, string? description = null, TimeSpan? duration = null,
        FoodType? foodType = null, string? imageUrl = null, ObservableCollection<IngredientAmountListModel>? ingredients = null)
        => new()
        {
            Id = model.Id,
            Name = name ?? model.Name,
            Description = description ?? model.Description,
            Duration = duration ?? model.Duration,
            FoodType = foodType ?? model.FoodType,
            ImageUrl = imageUrl ?? model.ImageUrl,
            Ingredients = ingredients ?? model.Ingredients
        };
}
