using System;
using System.Collections.Generic;
using System.Text;
using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mapper
{
    internal static class IngredientMapper
    {
        public static IngredientListModel MapListModel(IngredientEntity entity) =>
            new IngredientListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

        public static IngredientDetailModel MapDetailModel(IngredientEntity entity) =>
            new IngredientDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };

        public static IngredientEntity MapEntity(IngredientDetailModel model) =>
            new IngredientEntity
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name
            };

        public static IngredientEntity MapEntity(IngredientAmountDetailModel model) =>
            new IngredientEntity
            {
                Id = model.IngredientId,
                Description = model.IngredientDescription,
                Name = model.IngredientName
            };
    }
}
