using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public class RecipeRepository : Repository<RecipeEntity>
{
    private readonly RecipeEntityMapper recipeEntityMapper;

    public RecipeRepository(
        RecipeEntityMapper recipeEntityMapper,
        DbContext dbContext)
        : base(dbContext)
    {
        this.recipeEntityMapper = recipeEntityMapper;
    }

    public async Task<RecipeEntity> InsertOrUpdateAsync(RecipeEntity entity)
    {
        RecipeEntity result;

        if (Exists(entity))
        {
            var existingEntity = await dbSet.SingleAsync(e => e.Id == entity.Id);
            recipeEntityMapper.Map(existingEntity, entity);

            result = existingEntity;
        }
        else
        {
            result = Insert(entity);
        }

        return result;
    }
}