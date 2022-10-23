using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public interface IFacade<TEntity, TListModel, TDetailModel, TEntityMapper>
    where TEntity : class, IEntity
    where TListModel : IModel
    where TDetailModel : class, IModel
    where TEntityMapper : IEntityMapper<TEntity>, new()
{
    Task DeleteAsync(TDetailModel model);
    Task DeleteAsync(Guid id);
    Task<TDetailModel?> GetAsync(Guid id);
    Task<IEnumerable<TListModel>> GetAsync();
    Task<TDetailModel> SaveAsync(TDetailModel model);
}