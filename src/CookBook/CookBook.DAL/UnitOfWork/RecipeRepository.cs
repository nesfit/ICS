using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.UnitOfWork;

public class RecipeRepository : Repository<RecipeEntity>
{
    public RecipeRepository(
        DbContext dbContext,
        IEntityMapper<RecipeEntity> entityMapper)
        : base(dbContext, entityMapper)
    {
    }
}