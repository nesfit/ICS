using FIT.EFCore.Sample.DAL.Entities.Base;

namespace FIT.EFCore.Sample.DAL.Entities
{
    public class Todo : EntityBase
    {
        public string Task { get; set; }
        public bool IsDone { get; set; }
        public Person AssignedPerson { get; set; }
        public Group Group { get; set; }
    }
}
