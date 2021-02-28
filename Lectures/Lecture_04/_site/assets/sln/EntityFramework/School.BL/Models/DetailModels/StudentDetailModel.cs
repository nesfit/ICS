using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public class StudentDetailModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AddressDetailModel Address { get; set; }
        public GradeListModel Grade { get; set; }

        public ICollection<StudentCourseListModel> Courses { get; set; }

        private sealed class StudentDetailModelEqualityComparer : IEqualityComparer<StudentDetailModel>
        {
            public bool Equals(StudentDetailModel x, StudentDetailModel y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id.Equals(y.Id) 
                       && x.Name == y.Name 
                       && AddressDetailModel.AddressDetailModelComparer.Equals(x.Address, y.Address) 
                       && GradeListModel.IdNameComparer.Equals(x.Grade, y.Grade) 
                       && x.Courses.OrderBy(i=>i.Id).SequenceEqual(y.Courses.OrderBy(i=>i.Id), StudentCourseListModel.StudentCourseListModelComparer);
            }

            public int GetHashCode(StudentDetailModel obj)
            {
                return HashCode.Combine(obj.Id, obj.Name, obj.Address, obj.Grade, obj.Courses);
            }
        }

        public static IEqualityComparer<StudentDetailModel> StudentDetailModelComparer { get; } = new StudentDetailModelEqualityComparer();
    }
}