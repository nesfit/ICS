using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public record CourseDetailModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<StudentCourseListModel> Students { get; set; }
    }
}