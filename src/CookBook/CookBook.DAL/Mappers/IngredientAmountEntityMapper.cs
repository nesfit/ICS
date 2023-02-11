using CookBook.DAL.Entities;

namespace CookBook.DAL.Mappers;

public class IngredientAmountEntityMapper : IEntityMapper<IngredientAmountEntity>
{
    public void MapToExistingEntity(IngredientAmountEntity existingEntity, IngredientAmountEntity newEntity)
    {
        existingEntity.RecipeId = newEntity.RecipeId;
        existingEntity.IngredientId = newEntity.IngredientId;
        existingEntity.Amount = newEntity.Amount;
        existingEntity.Unit = newEntity.Unit;
    }
}
