using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public class RecipeRepository : Repository<RecipeEntity>
{
    public RecipeRepository(DbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<RecipeEntity> InsertOrUpdateAsync(RecipeEntity entity)
    {
        RecipeEntity result;

        if (Exists(entity))
        {
            throw new NotImplementedException();
        }
        else
        {
            result = Insert(entity);
        }

        return result;
    }
}