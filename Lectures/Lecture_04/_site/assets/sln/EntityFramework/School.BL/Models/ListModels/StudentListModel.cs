﻿using System;

namespace School.BL.Models.ListModels
{
    public record StudentListModel : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}