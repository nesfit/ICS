using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.BL.Enums;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public class RecipeDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public ICollection<IngredientAmountDetailModel> Ingredients { get; set; } = new List<IngredientAmountDetailModel>();

        private sealed class RecipeDetailModelEqualityComparer : IEqualityComparer<RecipeDetailModel>
        {
            public bool Equals(RecipeDetailModel x, RecipeDetailModel y)
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

                return string.Equals(x.Name, y.Name) 
                       && string.Equals(x.Description, y.Description) 
                       && x.Duration.Equals(y.Duration) 
                       && x.FoodType == y.FoodType 
                       && x.Ingredients.OrderBy(i=>i.Id).SequenceEqual(y.Ingredients.OrderBy(i=>i.Id),IngredientAmountDetailModel.IngredientAmountDetailModelComparer);
            }

            public int GetHashCode(RecipeDetailModel obj)
            {
                unchecked
                {
                    var hashCode = (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Description != null ? obj.Description.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Duration.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int) obj.FoodType;
                    hashCode = (hashCode * 397) ^ (obj.Ingredients != null ? obj.Ingredients.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<RecipeDetailModel> RecipeDetailModelComparer { get; } = new RecipeDetailModelEqualityComparer();


    }
}