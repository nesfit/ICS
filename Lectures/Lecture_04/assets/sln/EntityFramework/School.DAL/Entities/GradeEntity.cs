using System;
using System.Collections.Generic;

namespace School.DAL.Entities
{
    public class GradeEntity : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Section { get; set; }

        public virtual ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();

        private sealed class IdNameSectionEqualityComparer : IEqualityComparer<GradeEntity>
        {
            public bool Equals(GradeEntity x, GradeEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                //if (x.GetType() != y.GetType()) return false; //Allows lazy loading and its proxies
                return x.Id.Equals(y.Id) && x.Name == y.Name && x.Section == y.Section;
            }

            public int GetHashCode(GradeEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.Section);
            }
        }

        public static IEqualityComparer<GradeEntity> IdNameSectionComparer { get; } = new IdNameSectionEqualityComparer();
    }
}