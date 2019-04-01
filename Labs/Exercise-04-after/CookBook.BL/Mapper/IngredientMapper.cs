using System;
using System.Collections.Generic;
using System.Text;
using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mapper
{
    internal static class IngredientMapper
    {
        public static IngredientListModel MapIngredientEntityToListModel(IngredientEntity entity)
        {
            return new IngredientListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static IngredientDetailModel MapIngredientEntityToDetailModel(IngredientEntity entity)
        {
            return new IngredientDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public static IngredientEntity MapIngredientDetailModelToEntity(IngredientDetailModel model)
        {
            return new IngredientEntity
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name
            };
        }
    }
}
