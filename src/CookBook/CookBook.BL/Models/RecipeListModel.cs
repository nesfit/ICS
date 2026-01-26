using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Common.Enums;

namespace CookBook.BL.Models;

public partial class RecipeListModel : ModelBase
{
    [ObservableProperty]
    public required partial string Name { get; set; }

    [ObservableProperty]
    public required partial TimeSpan Duration { get; set; }

    [ObservableProperty]
    public partial FoodType FoodType { get; set; }

    [ObservableProperty]
    public partial string? ImageUrl { get; set; }

    public static RecipeListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Duration = TimeSpan.Zero
    };
}
