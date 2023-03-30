using AutoMapper;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public record IngredientListModel(string Name) : ModelBase
    {
        public string Name { get; set; } = Name;
        public string? ImageUrl { get; set; } 
        
        public class MapperProfile : Profile
        {
            public MapperProfile()
            {
                CreateMap<IngredientEntity, IngredientListModel>();
            }
        }
    }
}
