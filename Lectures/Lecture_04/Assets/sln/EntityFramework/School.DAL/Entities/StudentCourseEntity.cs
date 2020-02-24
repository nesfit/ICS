using System;
using System.Collections.Generic;

namespace School.DAL.Entities
{
    public class StudentCourseEntity : IEntity
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }

        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }

        private sealed class StudentCourseEntityEqualityComparer : IEqualityComparer<StudentCourseEntity>
        {
            public bool Equals(StudentCourseEntity x, StudentCourseEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                //if (x.GetType() != y.GetType()) return false; //Allows lazy loading and its proxies
                return x.Id.Equals(y.Id) 
                       && x.StudentId.Equals(y.StudentId) 
                       && x.CourseId.Equals(y.CourseId) 
                       && CourseEntity.IdNameDescriptionComparer.Equals(x.Course, y.Course);
            }

            public int GetHashCode(StudentCourseEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.StudentId, obj.CourseId, obj.Course);
            }
        }

        public static IEqualityComparer<StudentCourseEntity> StudentCourseEntityComparer { get; } = new StudentCourseEntityEqualityComparer();
    }
}