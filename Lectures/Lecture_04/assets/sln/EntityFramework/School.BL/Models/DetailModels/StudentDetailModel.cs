using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public record StudentDetailModel : IModel
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required AddressDetailModel Address { get; set; }
        public ProjectGroupListModel ProjectGroup { get; set; } = new();

        public ICollection<StudentCourseListModel> Courses { get; set; } = new List<StudentCourseListModel>();
    }
}
