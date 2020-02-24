using System;
using System.Collections.Generic;
using System.Text;
using CookBook.BL.Models;

namespace CookBook.BL.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<IngredientListModel> GetAll();
        IngredientDetailModel GetById(Guid id);
        IngredientDetailModel InsertOrUpdate(IngredientDetailModel model);
        void Delete(Guid id);
    }
}
