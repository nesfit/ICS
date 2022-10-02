using System;
using System.Collections.Generic;
using AutoMapper;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public record RecipeDetailModel : ModelBase
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<IngredientAmountDetailModel> Ingredients { get; init; } = new List<IngredientAmountDetailModel>();
        
        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<RecipeDetailModel, RecipeEntity>();
            }
        }

        public static RecipeDetailModel Empty => new()
        {
            Id = Guid.NewGuid(),
            Name = string.Empty,
            Description = string.Empty,
            Duration = TimeSpan.Zero,
        };
    }
}