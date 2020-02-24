using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public class CourseDetailModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<StudentCourseListModel> Students { get; set; }

        private sealed class IdNameDescriptionEqualityComparer : IEqualityComparer<CourseDetailModel>
        {
            public bool Equals(CourseDetailModel x, CourseDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) && x.Name == y.Name && x.Description == y.Description;
            }

            public int GetHashCode(CourseDetailModel obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.Description);
            }
        }

        public static IEqualityComparer<CourseDetailModel> IdNameDescriptionComparer { get; } = new IdNameDescriptionEqualityComparer();
    }
}