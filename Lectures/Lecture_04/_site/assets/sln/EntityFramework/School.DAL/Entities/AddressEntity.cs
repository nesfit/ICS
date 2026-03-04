using System;

namespace School.DAL.Entities
{
    public class AddressEntity : IEntity
    {
        public Guid Id { get; set; }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}
