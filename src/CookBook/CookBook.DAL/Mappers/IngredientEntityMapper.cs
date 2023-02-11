using CookBook.DAL.Entities;

namespace CookBook.DAL.Mappers;

public class IngredientEntityMapper : IEntityMapper<IngredientEntity>
{
    public void MapToExistingEntity(IngredientEntity existingEntity, IngredientEntity newEntity)
    {
        existingEntity.Name = newEntity.Name;
        existingEntity.Description = newEntity.Description;
        existingEntity.ImageUrl = newEntity.ImageUrl;
    }
}
