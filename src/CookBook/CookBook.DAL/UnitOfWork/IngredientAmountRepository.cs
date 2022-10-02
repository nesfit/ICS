using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public class IngredientAmountRepository : Repository<IngredientAmountEntity>
{
    public IngredientAmountRepository(DbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IngredientAmountEntity> InsertOrUpdateAsync(IngredientAmountEntity entity)
    {
        IngredientAmountEntity result;

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