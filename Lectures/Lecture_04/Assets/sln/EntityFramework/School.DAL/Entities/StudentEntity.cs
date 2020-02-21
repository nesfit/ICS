using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.Entities
{
    public class StudentEntity : IEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public virtual AddressEntity Address { get; set; }

        public Guid GradeId { get; set; }
        public virtual GradeEntity Grade { get; set; }

        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; } = new List<StudentCourseEntity>();

        private sealed class StudentEntityEqualityComparer : IEqualityComparer<StudentEntity>
        {
            public bool Equals(StudentEntity x, StudentEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                // if (x.GetType() == y.GetType()) return false; //Allows lazy loading and its proxies
                return x.Id.Equals(y.Id)
                       && x.Name == y.Name
                       && AddressEntity.AddressEntityComparer.Equals(x.Address, y.Address) // Address needs to be compared on members not reference
                       && Equals(x.GradeId, y.GradeId)
                       && GradeEntity.IdNameSectionComparer.Equals(x.Grade, y.Grade)
                       && x.StudentCourses.OrderBy(i => i.Id).SequenceEqual(y.StudentCourses.OrderBy(I => I.Id), StudentCourseEntity.StudentCourseEntityComparer); //Assigned courses needs to be ordered and compared on members
            }

            public int GetHashCode(StudentEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Address != null ? obj.Address.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Grade != null ? obj.Grade.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.StudentCourses != null ? obj.StudentCourses.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<StudentEntity> StudentEntityComparer { get; } = new StudentEntityEqualityComparer();
    }
}