using System;
using AutoMapper;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public record IngredientAmountDetailModel : ModelBase
    {
        public required Guid IngredientId { get; set; }
        public required string IngredientName { get; set; }
        public required string IngredientDescription { get; set; }
        public string? IngredientImageUrl { get; set; }
        public double Amount { get; set; }
        public Unit Unit { get; set; }

        public static IngredientAmountDetailModel Empty => new()
        {
            Id = Guid.NewGuid(),
            IngredientId = Guid.Empty,
            IngredientName = string.Empty,
            IngredientDescription = string.Empty,
        };

        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<IngredientAmountEntity, IngredientAmountDetailModel>()
                    .ReverseMap()
                    .ForMember(entity => entity.Ingredient, expression => expression.Ignore())
                    .ForMember(entity => entity.Recipe, expression => expression.Ignore())
                    .ForMember(entity => entity.RecipeId, expression => expression.Ignore());
            }
        }
    }
}