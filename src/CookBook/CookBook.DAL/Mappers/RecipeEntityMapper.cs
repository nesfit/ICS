using CookBook.DAL.Entities;

namespace CookBook.DAL.Mappers;

public class RecipeEntityMapper : IEntityMapper<RecipeEntity>
{
    public void MapToExistingEntity(RecipeEntity existingEntity, RecipeEntity newEntity)
    {
        existingEntity.Name = newEntity.Name;
        existingEntity.Description = newEntity.Description;
        existingEntity.Duration = newEntity.Duration;
        existingEntity.FoodType = newEntity.FoodType;
        existingEntity.ImageUrl = newEntity.ImageUrl;
    }
}
