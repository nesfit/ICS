using System;
using System.Collections.Generic;

namespace CookBook.BL.Models
{
    public class IngredientDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private sealed class NameDescriptionEqualityComparer : IEqualityComparer<IngredientDetailModel>
        {
            public bool Equals(IngredientDetailModel x, IngredientDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id
                       && x.Name == y.Name 
                       && x.Description == y.Description;
            }

            public int GetHashCode(IngredientDetailModel obj) => HashCode.Combine(obj.Id, obj.Name, obj.Description);
        }

        public static IEqualityComparer<IngredientDetailModel> AllMembersComparer { get; } = new NameDescriptionEqualityComparer();
    }
}