using System;
using System.Collections.Generic;

namespace CookBook.BL.Models
{
    public class IngredientListModel : ModelBase
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        private sealed class AllMembersEqualityComparer : IEqualityComparer<IngredientListModel>
        {
            public bool Equals(IngredientListModel x, IngredientListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id)
                       && x.Name == y.Name
                       && x.ImageUrl == y.ImageUrl;
            }

            public int GetHashCode(IngredientListModel obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.ImageUrl != null ? obj.ImageUrl.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<IngredientListModel> AllMembersComparer { get; } = new AllMembersEqualityComparer();

    }
}
