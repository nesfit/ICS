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
        public string ImageUrl { get; set; }

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

                return x.Id == y.Id
                       && string.Equals(x.Name, y.Name)
                       && x.Duration.Equals(y.Duration)
                       && x.FoodType == y.FoodType
                       && string.Equals(x.ImageUrl, y.ImageUrl);
            }

            public int GetHashCode(RecipeListModel obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Duration.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int)obj.FoodType;
                    hashCode = (hashCode * 397) ^ (obj.ImageUrl != null ? obj.ImageUrl.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<RecipeListModel> NameDurationFoodTypeComparer { get; } = new NameDurationFoodTypeEqualityComparer();
    }
}