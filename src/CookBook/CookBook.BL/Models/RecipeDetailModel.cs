using System.Collections.ObjectModel;
using CookBook.Common.Enums;

namespace CookBook.BL.Models;

public record RecipeDetailModel : ModelBase
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required TimeSpan Duration { get; set; }
    public FoodType FoodType { get; set; }
    public string? ImageUrl { get; set; }
    public ObservableCollection<IngredientAmountListModel> Ingredients { get; init; } = new();

    public static RecipeDetailModel Empty => new()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Description = string.Empty,
        Duration = TimeSpan.Zero
    };
}
