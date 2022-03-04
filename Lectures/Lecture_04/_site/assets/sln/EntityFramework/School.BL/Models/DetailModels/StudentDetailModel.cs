using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public record StudentDetailModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AddressDetailModel Address { get; set; }
        public GradeListModel Grade { get; set; }

        public ICollection<StudentCourseListModel> Courses { get; set; }
    }
}