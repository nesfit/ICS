using System;
using System.Collections.Generic;

namespace School.BL.Models.ListModels
{
    public class StudentCourseListModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }

        private sealed class StudentCourseListModelEqualityComparer : IEqualityComparer<StudentCourseListModel>
        {
            public bool Equals(StudentCourseListModel x, StudentCourseListModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.Name == y.Name && x.CourseId.Equals(y.CourseId) && x.StudentId.Equals(y.StudentId);
            }

            public int GetHashCode(StudentCourseListModel obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.CourseId, obj.StudentId);
            }
        }

        public static IEqualityComparer<StudentCourseListModel> StudentCourseListModelComparer { get; } = new StudentCourseListModelEqualityComparer();
    }
}