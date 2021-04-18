using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Repositories
{
    public class IngredientRepository : RepositoryBase<IngredientEntity, IngredientListModel, IngredientDetailModel>, IIngredientRepository
    {
        public IngredientRepository(IDbContextFactory<CookBookDbContext> dbContextFactory)
            : base(dbContextFactory,
                IngredientMapper.MapDetailModelToEntity,
                IngredientMapper.MapEntityToListModel,
                IngredientMapper.MapEntityToDetailModel,
                null,
                null,
                null)
        {
        }
    }
}