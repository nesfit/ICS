using System;
using CookBook.Common.Enums;

namespace CookBook.BL.Models
{
    public record RecipeListModel : ModelBase
    {
        public string Name { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public string? ImageUrl { get; set; }
    }
}