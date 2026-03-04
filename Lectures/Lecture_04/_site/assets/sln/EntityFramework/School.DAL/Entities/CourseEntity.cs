using System;
using System.Collections.Generic;

namespace School.DAL.Entities
{
    public class CourseEntity : IEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; } = new List<StudentCourseEntity>();
    }
}
