using System;
using AutoMapper;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public record IngredientAmountDetailModel(
        Guid IngredientId,
        string IngredientName,
        string IngredientDescription,
        double Amount,
        Unit Unit) : ModelBase
    {
        public Guid IngredientId { get; set; } = IngredientId;
        public string IngredientName { get; set; } = IngredientName;
        public string IngredientDescription { get; set; } = IngredientDescription;
        public string? IngredientImageUrl { get; set; }
        public double Amount { get; set; } = Amount;
        public Unit Unit { get; set; } = Unit;

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