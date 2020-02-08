using System;
using CookBook.DAL.Enums;
using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public class IngredientAmountEntity : EntityBase
    {
        public double Amount { get; set; }
        public Unit Unit { get; set; }
        public Guid RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public IngredientEntity Ingredient { get; set; }

        private sealed class IngredientAmountEqualityComparer : IEqualityComparer<IngredientAmountEntity>
        {
            public bool Equals(IngredientAmountEntity x, IngredientAmountEntity y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }
                return x.Amount.Equals(y.Amount) &&
                       IngredientEntity.DescriptionNameIdComparer.Equals(x.Ingredient, y.Ingredient) &&
                       RecipeEntity.WithoutIngredientsComparer.Equals(x.Recipe, y.Recipe) && x.Unit == y.Unit &&
                       x.Id.Equals(y.Id);
            }

            public int GetHashCode(IngredientAmountEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Amount.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Ingredient != null ? obj.Ingredient.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Recipe != null ? obj.Recipe.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (int)obj.Unit;
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<IngredientAmountEntity> IngredientAmountComparer { get; } = new IngredientAmountEqualityComparer();
    }
}
