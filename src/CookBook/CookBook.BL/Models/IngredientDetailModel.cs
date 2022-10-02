using AutoMapper;
using CookBook.DAL.Entities;
using System;

namespace CookBook.BL.Models
{
    public record IngredientDetailModel : ModelBase
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
        
        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<IngredientDetailModel, IngredientEntity>();
            }
        }

        public static IngredientDetailModel Empty => new()
        {
            Id = Guid.NewGuid(),
            Name = string.Empty,
            Description = string.Empty,
        };
    }
}