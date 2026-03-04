using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public record AddressDetailModel : IModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }

        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
    }
}
