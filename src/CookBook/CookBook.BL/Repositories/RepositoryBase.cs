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
        protected readonly Func<TEntity, IEnumerable<IEntity>>[]? CollectionsToBeSynchronized;
        protected readonly IDbContextFactory<CookBookDbContext> DbContextFactory;
        protected readonly Func<TEntity?, TDetailModel?> MapDetailModel;
        protected readonly Func<TDetailModel?, TEntity?> MapEntity;
        protected readonly Func<TEntity?, TListModel?> MapListModel;

        protected readonly Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? DetailIncludes;
        protected readonly Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? ListIncludes;


        public RepositoryBase(IDbContextFactory<CookBookDbContext> dbContextFactory,
            Func<TDetailModel?, TEntity?> mapEntity,
            Func<TEntity?, TListModel?> mapListModel,
            Func<TEntity?, TDetailModel?> mapDetailModel,
            Func<TEntity, IEnumerable<IEntity>>[]? collectionsToBeSynchronized,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? detailIncludes,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? listIncludes)
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
            using CookBookDbContext dbContext = DbContextFactory.CreateDbContext();
            Delete(dbContext, id);
            dbContext.SaveChanges();
        }

        public TDetailModel? GetById(Guid entityId)
        {
            using CookBookDbContext dbContext = DbContextFactory.CreateDbContext();
            return MapDetailModel(GetById(dbContext, entityId));
        }

        public TDetailModel InsertOrUpdate(TDetailModel detailModel)
        {
            using CookBookDbContext dbContext = DbContextFactory.CreateDbContext();
            TEntity entity = MapEntity(detailModel)!;
            dbContext.Update<TEntity>(entity);
            SynchronizeCollections(dbContext, entity);

#if DEBUG
            DisplayStates(dbContext.ChangeTracker.Entries());
#endif

            dbContext.SaveChanges();

            return MapDetailModel(entity)!;
        }

        public IEnumerable<TListModel> GetAll()
        {
            using CookBookDbContext dbContext = DbContextFactory.CreateDbContext();
            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            if (ListIncludes != null)
            {
                query = ListIncludes(query);
            }

            return query.AsEnumerable().Select(e => MapListModel(e)!).ToArray();
        }

        private static void Delete(DbContext dbContext, Guid id)
        {
            var entity = dbContext.Find(typeof(TEntity), id);
            if (entity is not null)
            {
                dbContext.Remove(entity);
            }
        }

        private TEntity? GetById(DbContext dbContext, Guid entityId)
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
            TEntity? entityInDb;
            using (CookBookDbContext dbContextGetById = DbContextFactory.CreateDbContext())
            {
                entityInDb = GetById(dbContextGetById, entity.Id);
                if (entityInDb == null)
                {
                    return;
                }
            }

            foreach (Func<TEntity, IEnumerable<IEntity>>? collectionSelector in CollectionsToBeSynchronized)
            {
                IEntity[] updatedCollection = collectionSelector(entity).ToArray();
                IEnumerable<IEntity> collectionInDb = collectionSelector(entityInDb);

                foreach (IEntity item in collectionInDb)
                {
                    if (!updatedCollection.Contains(item, RepositoryExtensions.IdComparer))
                    {
                        var referencedEntity = dbContext.Find(item.GetType(), item.Id);
                        if(referencedEntity is not null)
                        {
                            dbContext.Remove(referencedEntity);
                        }
                    }
                }
            }
        }

        private static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (EntityEntry entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
            }
        }
    }
}