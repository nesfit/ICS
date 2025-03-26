using System;
using System.Collections.Generic;

namespace School.BL.Models.ListModels
{
    public record ProjectGroupListModel : IModel
    {
        public Guid Id { get; set; }

        public int? AvailableSpots { get; set; }
    }
}