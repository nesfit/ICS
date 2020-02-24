using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public class GradeDetailModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Section { get; set; }

        public ICollection<StudentListModel> Students { get; set; }

        private sealed class IdNameSectionEqualityComparer : IEqualityComparer<GradeDetailModel>
        {
            public bool Equals(GradeDetailModel x, GradeDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.Name == y.Name && x.Section == y.Section;
            }

            public int GetHashCode(GradeDetailModel obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.Section);
            }
        }

        public static IEqualityComparer<GradeDetailModel> IdNameSectionComparer { get; } = new IdNameSectionEqualityComparer();
    }
}