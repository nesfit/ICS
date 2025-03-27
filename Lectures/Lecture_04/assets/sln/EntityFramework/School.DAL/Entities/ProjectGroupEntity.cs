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

        private sealed class IdMaxCapacityAvailableSpotsEqualityComparer : IEqualityComparer<ProjectGroupEntity>
        {
            public bool Equals(ProjectGroupEntity? x, ProjectGroupEntity? y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                //if (x.GetType() != y.GetType()) return false; //Allows lazy loading and its proxies
                return x.Id.Equals(y.Id) && x.MaxCapacity == y.MaxCapacity && x.AvailableSpots == y.AvailableSpots;
            }

            public int GetHashCode(ProjectGroupEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.MaxCapacity, obj.AvailableSpots);
            }
        }

        public static IEqualityComparer<ProjectGroupEntity> IdMaxCapacityAvailableSpotsComparer { get; } = new IdMaxCapacityAvailableSpotsEqualityComparer();
    }
}