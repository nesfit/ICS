using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.BL.Models;

public partial class IngredientDetailModel : ModelBase
{
    [ObservableProperty]
    public required partial string Name { get; set; }

    [ObservableProperty]
    public required partial string Description { get; set; }

    [ObservableProperty]
    public partial string? ImageUrl { get; set; }

    public static IngredientDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Description = string.Empty
    };
}
