﻿using System;
using System.Collections.Generic;
using System.Text;
using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mapper
{
    public static class IngredientMapper
    {
        public static IngredientListModel MapIngredientEntityToListModel(IngredientEntity entity)
        {
            return entity == null? null :  new IngredientListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static IngredientDetailModel MapIngredientEntityToDetailModel(IngredientEntity entity) =>
            new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };

        public static IngredientEntity MapIngredientDetailModelToEntity(IngredientDetailModel model) =>
            new(model.Id, model.Name, model.Description);
    }
}
