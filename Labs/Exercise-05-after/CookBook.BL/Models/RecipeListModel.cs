﻿using CookBook.DAL.Enums;
using System;

namespace CookBook.BL.Models
{
    public record RecipeListModel : ModelBase
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public string ImageUrl { get; set; }
    }
}