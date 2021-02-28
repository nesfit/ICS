using System;
using System.Collections.Generic;

namespace School.BL.Models.ListModels
{
    public record StudentCourseListModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}