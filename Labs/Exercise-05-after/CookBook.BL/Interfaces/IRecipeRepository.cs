using System;
using System.Collections.Generic;
using CookBook.BL.Models;

namespace CookBook.BL.Interfaces
{
    public interface IRecipeRepository
    {
        void Delete(RecipeDetailModel detailModel);
        void Delete(Guid id);
        RecipeDetailModel GetById(Guid entityId);
        RecipeDetailModel InsertOrUpdate(RecipeDetailModel detailModel);
        IEnumerable<RecipeListModel> GetAll();
    }
}