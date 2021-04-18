using Nemesis.Essentials.Design;
using System;
using System.Collections.Generic;
using CookBook.Common.Enums;

namespace CookBook.DAL.Entities
{
    public record RecipeEntity : EntityBase
    {
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public TimeSpan Duration { get; init; }
        public FoodType FoodType { get; init; }
        public string? ImageUrl { get; set; }

        public ICollection<IngredientAmountEntity> Ingredients { get; set; } = new ValueCollection<IngredientAmountEntity>(IngredientAmountEntity.IngredientAmountWithoutRecipeEntityComparer);
    }
}
