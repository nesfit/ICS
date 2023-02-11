using CookBook.DAL.Entities;

namespace CookBook.DAL.Mappers;

public interface IEntityMapper<TEntity>
    where TEntity : IEntity
{
    void MapToExistingEntity(TEntity existingEntity, TEntity newEntity);
}
