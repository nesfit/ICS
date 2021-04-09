using CookBook.BL.Models;
using CookBook.DAL;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Repositories
{
    public class RepositoryBase<TEntity, TListModel, TDetailModel> : IRepository<TEntity, TListModel, TDetailModel>
        where TEntity : class, IEntity, new()
        where TListModel : IModel, new()
        where TDetailModel : IModel, new()
    {
        protected readonly Func<TEntity, IEnumerable<IEntity>>[] CollectionsToBeSynchronized;
        protected readonly INamedDbContextFactory<CookBookDbContext> DbContextFactory;
        protected readonly Func<TEntity, TDetailModel> MapDetailModel;
        protected readonly Func<TDetailModel, TEntity> MapEntity;
        protected readonly Func<TEntity, TListModel> MapListModel;

        protected readonly Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> DetailIncludes;
        protected readonly Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> ListIncludes;


        public RepositoryBase(INamedDbContextFactory<CookBookDbContext> dbContextFactory,
            Func<TDetailModel, TEntity> mapEntity,
            Func<TEntity, TListModel> mapListModel,
            Func<TEntity, TDetailModel> mapDetailModel,
            Func<TEntity, IEnumerable<IEntity>>[] collectionsToBeSynchronized,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> detailIncludes,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> listIncludes)
        {
            DbContextFactory = dbContextFactory;
            MapEntity = mapEntity;
            MapListModel = mapListModel;
            MapDetailModel = mapDetailModel;
            CollectionsToBeSynchronized = collectionsToBeSynchronized;
            DetailIncludes = detailIncludes;
            ListIncludes = listIncludes;
        }

        public void Delete(TDetailModel detailModel)
        {
            Delete(detailModel.Id);
        }

        public void Delete(Guid id)
        {
            using var dbContext = DbContextFactory.Create();
            Delete(dbContext, id);
            dbContext.SaveChanges();
        }

        public TDetailModel GetById(Guid entityId)
        {
            using var dbContext = DbContextFactory.Create();
            return MapDetailModel(GetById(dbContext, entityId));
        }

        public TDetailModel InsertOrUpdate(TDetailModel detailModel)
        {
            using var dbContext = DbContextFactory.Create();
            var entity = MapEntity(detailModel);
            dbContext.Update<TEntity>(entity);
            SynchronizeCollections(dbContext, entity);

#if DEBUG
            DisplayStates(dbContext.ChangeTracker.Entries());
#endif

            dbContext.SaveChanges();

            return MapDetailModel(entity);
        }

        public IEnumerable<TListModel> GetAll()
        {
            using var dbContext = DbContextFactory.Create();
            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            if (ListIncludes != null)
            {
                query = ListIncludes(query);
            }

            return query.AsEnumerable().Select(e => MapListModel(e)).ToArray();
        }

        private void Delete(DbContext dbContext, Guid id)
        {
            Delete(dbContext, typeof(TEntity), id);
        }
        private void Delete(DbContext dbContext, Type entityType, Guid id)
        {
            dbContext.Remove(dbContext.Find(typeof(TEntity), id));
        }

        private TEntity GetById(DbContext dbContext, Guid entityId)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            if (DetailIncludes != null)
            {
                query = DetailIncludes(query);
            }

            return query.FirstOrDefault(entity => entity.Id == entityId);
        }

        private void SynchronizeCollections(DbContext dbContext, TEntity entity)
        {
            if (CollectionsToBeSynchronized == null)
            {
                return;
            }

            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            TEntity entityInDb;
            using (var dbContextGetById = DbContextFactory.Create())
            {
                entityInDb = GetById(dbContextGetById, entity.Id);
                if (entityInDb == null)
                {
                    return;
                }
            }

            foreach (var collectionSelector in CollectionsToBeSynchronized)
            {
                var updatedCollection = collectionSelector(entity).ToArray();
                var collectionInDb = collectionSelector(entityInDb);

                foreach (var item in collectionInDb)
                {
                    if (!updatedCollection.Contains(item, RepositoryExtensions.IdComparer))
                    {
                        dbContext.Remove(dbContext.Find(item.GetType(), item.Id));
                    }
                }
            }
        }

        private static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
            }
        }


    }
}