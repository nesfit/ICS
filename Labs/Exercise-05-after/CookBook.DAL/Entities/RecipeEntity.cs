using CookBook.DAL.Enums;
using Nemesis.Essentials.Design;
using System;
using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public record RecipeEntity : EntityBase
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
        public TimeSpan Duration { get; init; }
        public FoodType FoodType { get; init; }
        public string ImageUrl { get; set; }
        public ICollection<IngredientAmountEntity> Ingredients { get; } = new ValueCollection<IngredientAmountEntity>(IngredientAmountEntity.IngredientAmountWithoutRecipeEntityComparer);
    }
}
