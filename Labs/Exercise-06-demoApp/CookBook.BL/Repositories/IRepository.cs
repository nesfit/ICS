using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;

namespace CookBook.BL.Repositories
{
    public interface IRepository<TEntity, out TListModel, TDetailModel>
        where TEntity : class, IEntity, new()
        where TListModel : IModel, new()
        where TDetailModel : IModel, new()
    {
        TDetailModel InsertOrUpdate(TDetailModel model);
        void Delete(TDetailModel entity);
        void Delete(Guid entityId);
        TDetailModel? GetById(Guid entityId);
        IEnumerable<TListModel> GetAll();
    }
}