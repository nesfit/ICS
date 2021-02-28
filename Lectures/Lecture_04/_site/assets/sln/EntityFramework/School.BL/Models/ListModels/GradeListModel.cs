using System;
using System.Collections.Generic;

namespace School.BL.Models.ListModels
{
    public record GradeListModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}