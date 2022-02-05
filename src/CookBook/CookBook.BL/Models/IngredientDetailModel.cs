using AutoMapper;
using AutoMapper.EquivalencyExpression;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public record IngredientDetailModel(
        string Name,
        string Description) : ModelBase
    {
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
        public string? ImageUrl { get; set; }
        
        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<IngredientEntity, IngredientDetailModel>()
                    .ReverseMap();
            }
        }

        public static IngredientDetailModel Empty => new(string.Empty, string.Empty);
    }
}