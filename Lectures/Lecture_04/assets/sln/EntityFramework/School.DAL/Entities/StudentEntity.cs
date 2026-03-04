using System;
using System.Collections.Generic;

namespace School.DAL.Entities
{
    // Demos entities without records, we do advice to use records instead of classes
    public class StudentEntity : IEntity
    {
        public Guid Id { get; set; }
        
        public string? Name { get; set; }

        public virtual AddressEntity? Address { get; set; }

        public Guid ProjectGroupId { get; set; }
        public virtual ProjectGroupEntity? ProjectGroup { get; set; }

        public virtual ICollection<StudentCourseEntity> StudentCourses { get; set; } = new List<StudentCourseEntity>();
    }
}
