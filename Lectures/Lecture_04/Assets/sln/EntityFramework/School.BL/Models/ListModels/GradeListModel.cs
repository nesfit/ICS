using System;
using System.Collections.Generic;

namespace School.BL.Models.ListModels
{
    public class GradeListModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        private sealed class IdNameEqualityComparer : IEqualityComparer<GradeListModel>
        {
            public bool Equals(GradeListModel x, GradeListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.Name == y.Name;
            }

            public int GetHashCode(GradeListModel obj)
            {
                return HashCode.Combine(obj.Id, obj.Name);
            }
        }

        public static IEqualityComparer<GradeListModel> IdNameComparer { get; } = new IdNameEqualityComparer();
    }
}