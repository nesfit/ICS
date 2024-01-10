using CookBook.Common.Enums;

namespace CookBook.BL.Models;

public record RecipeListModel : ModelBase
{
    public required string Name { get; set; }
    public required TimeSpan Duration { get; set; }
    public FoodType FoodType { get; set; }
    public string? ImageUrl { get; set; }

    public static RecipeListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Duration = TimeSpan.Zero
    };
}
