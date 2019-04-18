using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.BL.Interfaces;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.DAL.Factories;

namespace CookBook.BL.Repositories.Obsolete
{
    [Obsolete]
    public class IngredientRepositoryObsolete 
    {
        private readonly IDbContextFactory dbContextFactory;

        public IngredientRepositoryObsolete(IDbContextFactory dbContextFactory) => this.dbContextFactory = dbContextFactory;

        public IEnumerable<IngredientListModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Ingredients
                    .Select(e => IngredientMapper.MapListModel(e))
                    .ToList();
            }
        }

        public IngredientDetailModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Ingredients.First(t => t.Id == id);
                return IngredientMapper.MapDetailModel(entity);
            }
        }

        public IngredientDetailModel Create(IngredientDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = IngredientMapper.MapEntity(model);
                dbContext.Ingredients.Add(entity);
                dbContext.SaveChanges();
                return IngredientMapper.MapDetailModel(entity);
            }
        }

        public void Update(IngredientDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = IngredientMapper.MapEntity(model);
                dbContext.Ingredients.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Ingredients.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}