using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;

namespace CookBook.BL.Repositories
{
    public class IngredientRepository : RepositoryBase<IngredientEntity, IngredientListModel, IngredientDetailModel>, IIngredientRepository
    {
        public IngredientRepository(INamedDbContextFactory<CookBookDbContext> dbContextFactory)
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