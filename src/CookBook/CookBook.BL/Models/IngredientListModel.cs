using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.BL.Models;

public partial class IngredientListModel : ModelBase
{
    [ObservableProperty]
    public required partial string Name { get; set; }

    [ObservableProperty]
    public partial string? ImageUrl { get; set; }

    public static IngredientListModel Empty
        => new()
        {
            Id = Guid.Empty,
            Name = string.Empty,
            ImageUrl = string.Empty
        };
}
