using CommunityToolkit.Mvvm.ComponentModel;
using CookBook.Common.Enums;

namespace CookBook.BL.Models;

public partial class IngredientAmountListModel : ModelBase
{
    [ObservableProperty]
    public required partial Guid IngredientId { get; set; }

    [ObservableProperty]
    public required partial string IngredientName { get; set; }

    [ObservableProperty]
    public required partial string? IngredientImageUrl { get; set; }

    [ObservableProperty]
    public required partial double Amount { get; set; }

    [ObservableProperty]
    public required partial Unit Unit { get; set; }

    public static IngredientAmountListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        IngredientId = Guid.Empty,
        IngredientName = string.Empty,
        IngredientImageUrl = null,
        Amount = 0.0,
        Unit = Unit.None
    };
}
