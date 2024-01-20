using CookBook.Common.Enums;

namespace CookBook.BL.Models;

public record IngredientAmountListModel : ModelBase
{
    public required Guid IngredientId { get; set; }
    public required string IngredientName { get; set; }
    public required string? IngredientImageUrl { get; set; }
    public required double Amount { get; set; }
    public required Unit Unit { get; set; }

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
