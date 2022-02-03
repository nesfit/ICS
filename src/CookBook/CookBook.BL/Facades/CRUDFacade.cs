using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Facades;

public class CRUDFacade<TEntity, TListModel, TDetailModel>
        where TEntity : class, IEntity
        where TListModel : IModel
        where TDetailModel : class, IModel
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        protected CRUDFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }

        public async Task DeleteAsync(TDetailModel model) => await this.DeleteAsync(model.Id);

        public async Task DeleteAsync(Guid id)
        {
            await using var uow = _unitOfWorkFactory.Create();
            uow.GetRepository<TEntity>().Delete(id);
            await uow.CommitAsync();
        }

        public async Task<TDetailModel> GetAsync(Guid id)
        {
            await using var uow = _unitOfWorkFactory.Create();
            var query = uow
                .GetRepository<TEntity>()
                .Get()
                .Where(e => e.Id == id);
            return await _mapper.ProjectTo<TDetailModel>(query).SingleAsync();
        }

        public async Task<IEnumerable<TListModel>> GetAsync()
        {
            await using var uow = _unitOfWorkFactory.Create();
            var query = uow
                .GetRepository<TEntity>()
                .Get();
            return await _mapper.ProjectTo<TListModel>(query).ToArrayAsync();
        }

        public async Task<TDetailModel> SaveAsync(TDetailModel model)
        {
            await using var uow = _unitOfWorkFactory.Create();

            await PreloadChangeTracker(model, uow);
            
            var entity = await uow
                .GetRepository<TEntity>()
                .DbSet
                .Persist(_mapper)
                .InsertOrUpdateAsync(model);
            await uow.CommitAsync();
            
            return await GetAsync(entity.Id);
        }

        private static async Task PreloadChangeTracker(TDetailModel model, IUnitOfWork uow) 
            => await uow
                .GetRepository<TEntity>()
                .DbSet
                .Where(e => e.Id == model.Id)
                .IncludeFirstLevelNavigationProperties(uow.Model)
                .FirstOrDefaultAsync();
    }
    
internal static class QueryableExtensions
{
    public static IQueryable<TEntity> IncludeFirstLevelNavigationProperties<TEntity>(this IQueryable<TEntity> query, Microsoft.EntityFrameworkCore.Metadata.IModel model) where TEntity : class
    {
        var navigationProperties = model.FindEntityType(typeof(TEntity))?.GetNavigations();
        if (navigationProperties == null)
            return query;

        foreach (var navigationProperty in navigationProperties)
        {
            query = query.Include(navigationProperty.Name);
        }

        return query;
    }
}