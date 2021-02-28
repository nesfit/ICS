using System;
using System.Collections.Generic;

namespace School.DAL.Entities
{
    public class CourseEntity : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; } = new List<StudentCourseEntity>();

        private sealed class IdNameDescriptionEqualityComparer : IEqualityComparer<CourseEntity>
        {
            public bool Equals(CourseEntity x, CourseEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                //if (x.GetType() != y.GetType()) return false; //Allows lazy loading and its proxies
                return x.Id.Equals(y.Id) 
                       && x.Name == y.Name 
                       && x.Description == y.Description;
            }

            public int GetHashCode(CourseEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.Description);
            }
        }

        public static IEqualityComparer<CourseEntity> IdNameDescriptionComparer { get; } = new IdNameDescriptionEqualityComparer();
    }
}