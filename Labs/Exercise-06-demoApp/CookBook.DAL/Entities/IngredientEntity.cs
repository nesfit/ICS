using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public class IngredientEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        private sealed class DescriptionNameIdEqualityComparer : IEqualityComparer<IngredientEntity>
        {
            public bool Equals(IngredientEntity x, IngredientEntity y)
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
                return x.Id.Equals(y.Id)
                       && string.Equals(x.Name, y.Name)
                       && string.Equals(x.Description, y.Description)
                       && string.Equals(x.ImageUrl, y.ImageUrl);
            }

            public int GetHashCode(IngredientEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Description != null ? obj.Description.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.ImageUrl != null ? obj.ImageUrl.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<IngredientEntity> DescriptionNameIdComparer { get; } = new DescriptionNameIdEqualityComparer();
    }
}
