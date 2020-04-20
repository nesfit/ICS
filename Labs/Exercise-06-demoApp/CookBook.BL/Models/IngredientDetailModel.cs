using System;
using System.Collections.Generic;

namespace CookBook.BL.Models
{
    public class IngredientDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        private sealed class AllMembersComparerEqualityComparer : IEqualityComparer<IngredientDetailModel>
        {
            public bool Equals(IngredientDetailModel x, IngredientDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id)
                       && x.Name == y.Name
                       && string.Equals(x.ImageUrl, y.ImageUrl);
            }

            public int GetHashCode(IngredientDetailModel obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Description != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.ImageUrl != null ? obj.ImageUrl.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<IngredientDetailModel> AllMembersComparer { get; } = new IngredientDetailModel.AllMembersComparerEqualityComparer();
    }
}