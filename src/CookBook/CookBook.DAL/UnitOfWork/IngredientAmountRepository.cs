using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public class IngredientAmountRepository : Repository<IngredientAmountEntity>
{
    private readonly IEntityMapper<IngredientAmountEntity> entityMapper;

    public IngredientAmountRepository(
        DbContext dbContext,
        IEntityMapper<IngredientAmountEntity> entityMapper)
        : base(dbContext, entityMapper)
    {
        this.entityMapper = entityMapper;
    }

    public async Task<IngredientAmountEntity> InsertOrUpdateAsync(IngredientAmountEntity entity)
    {
        IngredientAmountEntity result;

        if (Exists(entity))
        {
            var existingEntity = await dbSet.SingleAsync(e => e.Id == entity.Id);
            entityMapper.Map(existingEntity, entity);

            result = existingEntity;
        }
        else
        {
            result = Insert(entity);
        }

        return result;
    }
}