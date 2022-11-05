using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public class IngredientModelMapper : ModelMapperBase<IngredientEntity, IngredientListModel, IngredientDetailModel>, IIngredientModelMapper
{
    public override IngredientListModel MapToListModel(IngredientEntity? entity)
        => entity is null
        ? IngredientListModel.Empty 
        : new()
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.ImageUrl
        };

    public override IngredientDetailModel MapToDetailModel(IngredientEntity? entity)
        => entity is null 
            ? IngredientDetailModel.Empty 
            : new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
            };

    public override IngredientEntity MapToEntity(IngredientDetailModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
        };
}