using System;
using System.Collections.Generic;
using CookBook.BL.Enums;

namespace CookBook.BL.Models
{
    public class RecipeListModel : ModelBase
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }

        private sealed class NameDurationFoodTypeEqualityComparer : IEqualityComparer<RecipeListModel>
        {
            public bool Equals(RecipeListModel x, RecipeListModel y)
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

                return string.Equals(x.Name, y.Name) && x.Duration.Equals(y.Duration) && x.FoodType == y.FoodType;
            }

            public int GetHashCode(RecipeListModel obj)
            {
                unchecked
                {
                    var hashCode = (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Duration.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int) obj.FoodType;
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<RecipeListModel> NameDurationFoodTypeComparer { get; } = new NameDurationFoodTypeEqualityComparer();
    }
}