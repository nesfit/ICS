using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.UnitOfWork;

public class IngredientRepository : Repository<IngredientEntity>
{
    public IngredientRepository(
        DbContext dbContext,
        IEntityMapper<IngredientEntity> entityMapper)
        : base(dbContext, entityMapper)
    {
    }
}