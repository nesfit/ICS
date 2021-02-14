using CookBook.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Nemesis.Essentials.Design;

namespace CookBook.DAL.Entities
{
    public record RecipeEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public ICollection<IngredientAmountEntity> Ingredients { get; } = new ValueCollection<IngredientAmountEntity>(IngredientAmountEntity.IngredientAmountWithoutRecipeEntityComparer);
    }
}
