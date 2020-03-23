using CookBook.BL.Models;
using System;
using System.Collections.Generic;

namespace CookBook.BL.Repositories
{
    public interface IIngredientRepository
    {
        IList<IngredientListModel> GetAll();
        IngredientDetailModel GetById(Guid id);
        IngredientDetailModel Create(IngredientDetailModel model);
        void Update(IngredientDetailModel model);
        void Delete(Guid id);
    }
}
