using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.BL.Factories;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.DAL;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;

namespace CookBook.BL.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IDbContextFactory<CookBookDbContext> _dbContextFactory;

        public IngredientRepository(IDbContextFactory<CookBookDbContext> dbContextFactory)
        {
            this._dbContextFactory = dbContextFactory;
        }

        public IEnumerable<IngredientListModel> GetAll()
        {
            using var dbContext = _dbContextFactory.Create();

            return dbContext.Ingredients
                .Select(e => IngredientMapper.MapIngredientEntityToListModel(e)).ToArray();
        }

        public IngredientDetailModel GetById(Guid id)
        {
            using var dbContext = _dbContextFactory.Create();

            var entity = dbContext.Ingredients.Single(t => t.Id == id);

            return IngredientMapper.MapIngredientEntityToDetailModel(entity);
        }
        
        public IngredientDetailModel InsertOrUpdate(IngredientDetailModel model)
        {
            using var dbContext = _dbContextFactory.Create();

            var entity = IngredientMapper.MapIngredientDetailModelToEntity(model);

            dbContext.Ingredients.Update(entity);
            dbContext.SaveChanges();

            return IngredientMapper.MapIngredientEntityToDetailModel(entity);
        }

        public void Delete(Guid id)
        {
            using var dbContext = _dbContextFactory.Create();

            var entity = new IngredientEntity(){Id =  id};

            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}