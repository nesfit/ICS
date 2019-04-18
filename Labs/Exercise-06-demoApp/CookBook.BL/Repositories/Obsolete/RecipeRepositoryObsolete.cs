using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CookBook.BL.Repositories.Obsolete
{
    [Obsolete]

    public class RecipeRepositoryObsolete
    {
        private readonly IDbContextFactory dbContextFactory;

        public RecipeRepositoryObsolete(IDbContextFactory dbContextFactory) => this.dbContextFactory = dbContextFactory;


        public void Delete(RecipeDetailModel detailModel)
        {
            Delete(detailModel.Id);
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Delete(dbContext, id);
                dbContext.SaveChanges();
            }
        }

        public RecipeDetailModel GetById(Guid entityId)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return RecipeMapper.MapToDetailModel(GetById(dbContext, entityId));
            }
        }

        public RecipeDetailModel InsertOrUpdate(RecipeDetailModel detailModel)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = RecipeMapper.MapToEntity(detailModel);

                dbContext.Update(entity);
                SynchronizeCollections(dbContext, entity);

#if DEBUG
                DisplayStates(dbContext.ChangeTracker.Entries());
#endif

                dbContext.SaveChanges();

                return RecipeMapper.MapToDetailModel(entity);
            }
        }

        public IEnumerable<RecipeListModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                IQueryable<RecipeEntity> query = dbContext.Set<RecipeEntity>();

                return query.Select(e => RecipeMapper.MapToListModel(e)).ToArray();
            }
        }

        private void Delete(DbContext dbContext, Guid id)
        {
            Delete(dbContext, typeof(RecipeEntity), id);
        }

        private void Delete(DbContext dbContext, Type entityType, Guid id)
        {
            dbContext.Remove(dbContext.Find(typeof(RecipeEntity), id));
        }

        private RecipeEntity GetById(DbContext dbContext, Guid entityId)
        {
            IQueryable<RecipeEntity> query = dbContext.Set<RecipeEntity>().Include(entity => entity.Ingredients)
                .ThenInclude(entity => entity.Ingredient);


            return query.FirstOrDefault(entity => entity.Id == entityId);
        }

        private void SynchronizeCollections(DbContext dbContext, RecipeEntity entity)
        {
            IQueryable<RecipeEntity> query = dbContext.Set<RecipeEntity>();
            RecipeEntity entityInDb;
            using (var dbContextGetById = dbContextFactory.CreateDbContext())
            {
                entityInDb = GetById(dbContextGetById, entity.Id);
                if (entityInDb == null)
                {
                    return;
                }
            }

            foreach (var item in entityInDb.Ingredients)
            {
                if (!entity.Ingredients.Contains(item, RepositoryExtensions.IdComparer))
                {
                    dbContext.Remove(dbContext.Find(item.GetType(), item.Id));
                }
            }
        }

        private static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}");
            }
        }

       
    }
}