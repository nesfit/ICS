
using System;
using System.Collections.Generic;
using CookBook.BL.Enums;

namespace CookBook.BL.Models
{
    public class IngredientAmountDetailModel : ModelBase
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string IngredientDescription { get; set; }
        public double Amount { get; set; }
        public Unit Unit { get; set; }

        private sealed class IngredientAmountDetailModelEqualityComparer : IEqualityComparer<IngredientAmountDetailModel>
        {
            public bool Equals(IngredientAmountDetailModel x, IngredientAmountDetailModel y)
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

                return x.IngredientId.Equals(y.IngredientId) 
                       && string.Equals(x.IngredientName, y.IngredientName) 
                       && string.Equals(x.IngredientDescription, y.IngredientDescription) 
                       && x.Amount.Equals(y.Amount) && x.Unit == y.Unit;
            }

            public int GetHashCode(IngredientAmountDetailModel obj)
            {
                unchecked
                {
                    var hashCode = obj.IngredientId.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.IngredientName != null ? obj.IngredientName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.IngredientDescription != null ? obj.IngredientDescription.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Amount.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int) obj.Unit;
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<IngredientAmountDetailModel> IngredientAmountDetailModelComparer { get; } = new IngredientAmountDetailModelEqualityComparer();

        private sealed class IngredientAmountDetailModelWithoutIdEqualityComparer : IEqualityComparer<IngredientAmountDetailModel>
        {
            public bool Equals(IngredientAmountDetailModel x, IngredientAmountDetailModel y)
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

                return string.Equals(x.IngredientName, y.IngredientName) 
                       && string.Equals(x.IngredientDescription, y.IngredientDescription) 
                       && x.Amount.Equals(y.Amount) 
                       && x.Unit == y.Unit;
            }

            public int GetHashCode(IngredientAmountDetailModel obj)
            {
                unchecked
                {
                    var hashCode = obj.IngredientName.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.IngredientDescription != null ? obj.IngredientDescription.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Amount.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int) obj.Unit;
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<IngredientAmountDetailModel> IngredientAmountDetailModelWithoutIdComparer { get; } = new IngredientAmountDetailModelWithoutIdEqualityComparer();
    }
}