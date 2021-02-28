using System;
using System.Collections.Generic;

namespace School.DAL.Entities
{
    public class AddressEntity : IEntity
    {
        public Guid Id { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        private sealed class AddressEntityEqualityComparer : IEqualityComparer<AddressEntity>
        {
            public bool Equals(AddressEntity x, AddressEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                // if (x.GetType() == y.GetType()) return false; //Allows lazy loading and its proxies
                return x.Id.Equals(y.Id)
                       && x.Street == y.Street
                       && x.City == y.City
                       && x.State == y.State
                       && x.Country == y.Country;
            }

            public int GetHashCode(AddressEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Street != null ? obj.Street.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.City != null ? obj.City.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.State != null ? obj.State.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Country != null ? obj.Country.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<AddressEntity> AddressEntityComparer { get; } = new AddressEntityEqualityComparer();
    }
}