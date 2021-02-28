using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public record AddressDetailModel : IModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }


        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}