using System.Collections.Generic;
using FIT.EFCore.Sample.DAL.Entities.Base;

namespace FIT.EFCore.Sample.DAL.Entities
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}