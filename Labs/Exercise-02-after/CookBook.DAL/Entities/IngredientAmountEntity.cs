using System;
using CookBook.DAL.Enums;
using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public record IngredientAmountEntity : EntityBase
    {
        public double Amount { get; set; }
        public Unit Unit { get; set; }
        public Guid RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public IngredientEntity Ingredient { get; set; }

        private sealed class IngredientAmountWithoutRecipeEntityEqualityComparer : IEqualityComparer<IngredientAmountEntity>
        {
            public bool Equals(IngredientAmountEntity x, IngredientAmountEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Amount.Equals(y.Amount) && x.Unit == y.Unit && x.RecipeId.Equals(y.RecipeId) && x.IngredientId.Equals(y.IngredientId) && Equals(x.Ingredient, y.Ingredient);
            }

            public int GetHashCode(IngredientAmountEntity obj)
            {
                return HashCode.Combine(obj.Amount, (int) obj.Unit, obj.RecipeId, obj.IngredientId, obj.Ingredient);
            }
        }

        public static IEqualityComparer<IngredientAmountEntity> IngredientAmountWithoutRecipeEntityComparer { get; } = new IngredientAmountWithoutRecipeEntityEqualityComparer();
    }
}
