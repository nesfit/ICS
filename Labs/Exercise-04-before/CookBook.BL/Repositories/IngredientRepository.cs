using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.BL.Factories;
using CookBook.BL.Mapper;
using CookBook.BL.Models;

namespace CookBook.BL.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public IngredientRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<IngredientListModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Ingredients
                    .Select(e => IngredientMapper.MapIngredientEntityToListModel(e));
            }
        }

        public IngredientDetailModel GetById(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                //SELECT * FROM Ingredient WHERE Id = id;
                var entity = dbContext.Ingredients.First(t => t.Id == id);
                return IngredientMapper.MapIngredientEntityToDetailModel(entity);
            }
        }

        public IngredientDetailModel Create(IngredientDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = IngredientMapper.MapIngredientDetailModelToEntity(model);
                dbContext.Ingredients.Add(entity);
                dbContext.SaveChanges();
                return IngredientMapper.MapIngredientEntityToDetailModel(entity);
            }
        }

        public void Update(IngredientDetailModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = IngredientMapper.MapIngredientDetailModelToEntity(model);
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