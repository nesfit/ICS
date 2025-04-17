using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Common.Enums;

namespace CookBook.BL.Models;

public partial class IngredientAmountDetailModel : ModelBase
{
    [ObservableProperty]
    public required partial  Guid IngredientId { get; set; }

    [ObservableProperty]
    public required partial string IngredientName { get; set; }

    [ObservableProperty]
    public required partial string IngredientDescription { get; set; }

    [ObservableProperty]
    public partial string? IngredientImageUrl { get; set; }

    [ObservableProperty]
    public partial double Amount { get; set; }

    [ObservableProperty]
    public partial Unit Unit { get; set; }

    public static IngredientAmountDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        IngredientId = Guid.Empty,
        IngredientName = string.Empty,
        IngredientDescription = string.Empty
    };
}
