using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public record ProjectGroupDetailModel : IModel
    {
        public Guid Id { get; set; }

        public int? MaxCapacity { get; set; }
        public int? AvailableSpots { get; set; }

        public ICollection<StudentListModel> Students { get; set; }
    }
}