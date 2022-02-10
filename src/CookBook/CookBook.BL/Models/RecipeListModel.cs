using System;
using AutoMapper;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public record RecipeListModel(
        string Name,
        TimeSpan Duration,
        FoodType FoodType) : ModelBase
    {
        public string Name { get; set; } = Name;
        public TimeSpan Duration { get; set; } = Duration;
        public FoodType FoodType { get; set; } = FoodType;
        public string? ImageUrl { get; set; }

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<RecipeEntity, RecipeListModel>();
            }
        }
    }
}