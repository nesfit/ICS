using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Nemesis.Essentials.Design;

namespace CookBook.BL.Models
{
    public record RecipeDetailModel(
        string Name,
        string Description,
        TimeSpan Duration,
        FoodType FoodType) : ModelBase
    {
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
        public TimeSpan Duration { get; set; } = Duration;
        public FoodType FoodType { get; set; } = FoodType;
        public string? ImageUrl { get; set; }
        public List<IngredientAmountDetailModel> Ingredients { get; init; } = new();
        
        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<RecipeEntity, RecipeDetailModel>()
                    .ReverseMap();
            }
        }

        public static RecipeDetailModel Empty => new(string.Empty, string.Empty, default, default);
    }
}