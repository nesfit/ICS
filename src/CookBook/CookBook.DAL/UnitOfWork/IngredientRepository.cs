using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CookBook.DAL.UnitOfWork;

public class IngredientRepository : Repository<IngredientEntity>
{
    private readonly IngredientEntityMapper ingredientEntityMapper;

    public IngredientRepository(
        IngredientEntityMapper ingredientEntityMapper,
        DbContext dbContext)
        : base(dbContext)
    {
        this.ingredientEntityMapper = ingredientEntityMapper;
    }

    public IngredientEntity Update(IngredientEntity entity)
    {
        var existingEntity = dbSet.Single(e => e.Id == entity.Id);
        ingredientEntityMapper.Map(existingEntity, entity);
        return existingEntity;
    }
}