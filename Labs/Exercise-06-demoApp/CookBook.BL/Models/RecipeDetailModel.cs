using System;
using System.Collections.Generic;
using CookBook.Common.Enums;
using Nemesis.Essentials.Design;

namespace CookBook.BL.Models
{
    public record RecipeDetailModel : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<IngredientAmountDetailModel> Ingredients { get; set; } = new  ValueCollection<IngredientAmountDetailModel>();
    }
}