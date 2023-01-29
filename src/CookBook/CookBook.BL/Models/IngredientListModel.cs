using System;

namespace CookBook.BL.Models;

public record IngredientListModel : ModelBase
{
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }

    public static IngredientListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        ImageUrl = string.Empty,
    };
}