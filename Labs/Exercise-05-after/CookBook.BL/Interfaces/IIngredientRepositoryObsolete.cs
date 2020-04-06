using System;
using System.Collections.Generic;
using CookBook.BL.Models;

namespace CookBook.BL.Interfaces
{
    public interface IIngredientRepositoryObsolete
    {
        void Delete(IngredientDetailModel detailModel);
        void Delete(Guid id);
        IngredientDetailModel GetById(Guid entityId);
        IngredientDetailModel InsertOrUpdate(IngredientDetailModel detailModel);
        IEnumerable<IngredientListModel> GetAll();
    }
}