using System;

namespace School.BL.Models.ListModels
{
    public class CourseListModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}