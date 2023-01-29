using CookBook.BL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Facades;

public abstract class FacadeBase<TEntity, TListModel, TDetailModel, TEntityMapper> : IFacade<TEntity, TListModel, TDetailModel>
        where TEntity : class, IEntity
        where TListModel : IModel
        where TDetailModel : class, IModel
        where TEntityMapper : IEntityMapper<TEntity>, new()
{ 
    protected readonly IModelMapper<TEntity, TListModel, TDetailModel> modelMapper;
    protected readonly IUnitOfWorkFactory unitOfWorkFactory;

    protected virtual string includesNavigationPathDetail => string.Empty;

    protected FacadeBase(
        IUnitOfWorkFactory unitOfWorkFactory,
        IModelMapper<TEntity, TListModel, TDetailModel> modelMapper)
    {
        this.unitOfWorkFactory = unitOfWorkFactory;
        this.modelMapper = modelMapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        uow.GetRepository<TEntity, TEntityMapper>().Delete(id);
        await uow.CommitAsync().ConfigureAwait(false);
    }

    public virtual async Task<TDetailModel?> GetAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();

        var query = uow.GetRepository<TEntity, TEntityMapper>().Get();

        if (string.IsNullOrWhiteSpace(includesNavigationPathDetail) is false)
        {
            query = query.Include(includesNavigationPathDetail);
        }

        var entity = await query.SingleOrDefaultAsync(e => e.Id == id);

        return entity is null
            ? null
            : modelMapper.MapToDetailModel(entity);
    }

    public virtual async Task<IEnumerable<TListModel>> GetAsync()
    {
        await using var uow = unitOfWorkFactory.Create();
        var entities = uow
            .GetRepository<TEntity, TEntityMapper>()
            .Get()
            .ToList();

        return modelMapper.MapToListModel(entities);
    }

    public virtual async Task<TDetailModel> SaveAsync(TDetailModel model)
    {
        TDetailModel result;

        var entity = modelMapper.MapToEntity(model);

        var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<TEntity, TEntityMapper>();

        if (repository.Exists(entity))
        {
            var updatedEntity = repository.Update(entity);
            result = modelMapper.MapToDetailModel(updatedEntity);
        }
        else
        {
            var insertedEntity = repository.Insert(entity);
            result = modelMapper.MapToDetailModel(insertedEntity);
        }

        await uow.CommitAsync();

        return result;
    }
}