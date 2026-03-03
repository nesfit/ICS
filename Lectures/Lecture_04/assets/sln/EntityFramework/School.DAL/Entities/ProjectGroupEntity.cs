using System;
using System.Collections.Generic;

namespace School.DAL.Entities
{
    public class ProjectGroupEntity : IEntity
    {
        public Guid Id { get; set; }

        public int? MaxCapacity { get; set; }
        public int? AvailableSpots { get; set; }

        public virtual ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();
    }
}
