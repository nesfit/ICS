using System.Collections.Generic;
using FIT.EFCore.Sample.DAL.Entities.Base;

namespace FIT.EFCore.Sample.DAL.Entities
{
    public class Group : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}