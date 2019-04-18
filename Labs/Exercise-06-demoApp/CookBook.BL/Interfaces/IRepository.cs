using System;
using System.Collections.Generic;
using CookBook.BL.Models;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Interfaces
{
    public interface IRepository<TEntity, out TListModel, TDetailModel> where TEntity :
        class, IEntity, new() 
        where TListModel : ModelBase, new() 
        where TDetailModel : ModelBase, new()
    {
        TDetailModel InsertOrUpdate(TDetailModel model);
        void Delete(TDetailModel entity);
        void Delete(Guid entityId);
        TDetailModel GetById(Guid entityId);
        IEnumerable<TListModel> GetAll();
    }
}