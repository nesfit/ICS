using System;
using System.Collections.Generic;
using CookBook.Common.Enums;

namespace CookBook.DAL.Entities
{
    public record IngredientAmountEntity : EntityBase
    {
        public double Amount { get; init; }
        public Unit Unit { get; init; }
        public Guid RecipeId { get; init; }
        public RecipeEntity? Recipe { get; init; }
        public Guid IngredientId { get; init; }
        public IngredientEntity? Ingredient { get; init; }

        private sealed class IngredientAmountWithoutRecipeEntityEqualityComparer : IEqualityComparer<IngredientAmountEntity>
        {
            public bool Equals(IngredientAmountEntity? x, IngredientAmountEntity? y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Amount.Equals(y.Amount) 
                       && x.Unit == y.Unit 
                       && x.RecipeId.Equals(y.RecipeId) 
                       && x.IngredientId.Equals(y.IngredientId) 
                       && Equals(x.Ingredient, y.Ingredient);
            }

            public int GetHashCode(IngredientAmountEntity obj) 
                => HashCode.Combine(obj.Amount, (int) obj.Unit, obj.RecipeId, obj.IngredientId, obj.Ingredient);
        }

        public static IEqualityComparer<IngredientAmountEntity> IngredientAmountWithoutRecipeEntityComparer { get; } 
            = new IngredientAmountWithoutRecipeEntityEqualityComparer();
    }
}
