using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public class IngredientAmountRepository : Repository<IngredientAmountEntity>
{
    private readonly IngredientAmountEntityMapper ingredientAmountEntityMapper;

    public IngredientAmountRepository(
        IngredientAmountEntityMapper ingredientAmountEntityMapper,
        DbContext dbContext)
        : base(dbContext)
    {
        this.ingredientAmountEntityMapper = ingredientAmountEntityMapper;
    }

    public async Task<IngredientAmountEntity> InsertOrUpdateAsync(IngredientAmountEntity entity)
    {
        IngredientAmountEntity result;

        if (Exists(entity))
        {
            var existingEntity = await dbSet.SingleAsync(e => e.Id == entity.Id);
            ingredientAmountEntityMapper.Map(existingEntity, entity);

            result = existingEntity;
        }
        else
        {
            result = Insert(entity);
        }

        return result;
    }
}