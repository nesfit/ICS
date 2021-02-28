using System;
using System.Collections.Generic;
using School.BL.Models.ListModels;

namespace School.BL.Models.DetailModels
{
    public record GradeDetailModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Section { get; set; }

        public ICollection<StudentListModel> Students { get; set; }
    }
}