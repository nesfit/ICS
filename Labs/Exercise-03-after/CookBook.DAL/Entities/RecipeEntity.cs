using CookBook.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Nemesis.Essentials.Design;

namespace CookBook.DAL.Entities
{
    public record RecipeEntity : EntityBase
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
        public TimeSpan Duration { get; init; }
        public FoodType FoodType { get; init; }
        public ICollection<IngredientAmountEntity> Ingredients { get; } = new ValueCollection<IngredientAmountEntity>(IngredientAmountEntity.IngredientAmountWithoutRecipeEntityComparer);
    }
}
