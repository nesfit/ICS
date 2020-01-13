using System;
using System.Collections.Generic;
using CookBook.Common;

namespace CookBook.DAL.Interfaces
{
    public interface IRepository<TEntity, out TListModel, TDetailModel> where TEntity :
        class, IEntity, new() 
        where TListModel : IId, new() 
        where TDetailModel : IId, new()
    {
        TDetailModel InsertOrUpdate(TDetailModel model);
        void Delete(TDetailModel entity);
        void Delete(Guid entityId);
        TDetailModel GetById(Guid entityId);
        IEnumerable<TListModel> GetAll();
    }
}