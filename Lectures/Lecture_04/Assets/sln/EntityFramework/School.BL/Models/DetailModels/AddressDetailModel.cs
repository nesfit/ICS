using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public class AddressDetailModel : IModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }


        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        private sealed class AddressDetailModelEqualityComparer : IEqualityComparer<AddressDetailModel>
        {
            public bool Equals(AddressDetailModel x, AddressDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.StudentId.Equals(y.StudentId) && x.Street == y.Street && x.City == y.City && x.State == y.State && x.Country == y.Country;
            }

            public int GetHashCode(AddressDetailModel obj)
            {
                return HashCode.Combine(obj.Id, obj.StudentId, obj.Street, obj.City, obj.State, obj.Country);
            }
        }

        public static IEqualityComparer<AddressDetailModel> AddressDetailModelComparer { get; } = new AddressDetailModelEqualityComparer();
    }
}