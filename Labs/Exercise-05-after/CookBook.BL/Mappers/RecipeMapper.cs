﻿using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using System.Linq;

namespace CookBook.BL.Mappers
{
    internal static class RecipeMapper
    {
        public static RecipeDetailModel MapEntityToDetailModel(RecipeEntity entity) =>
            entity == null
                ? null
                : new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    FoodType = (FoodType)entity.FoodType,
                    Duration = entity.Duration,
                    ImageUrl = entity.ImageUrl,
                    Ingredients = entity.Ingredients.Select(IngredientAmountMapper.MapEntityToDetailModel).ToList()
                };

        public static RecipeListModel MapEntityToListModel(RecipeEntity entity) =>
            entity == null
                ? null
                : new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Duration = entity.Duration,
                    FoodType = (FoodType)entity.FoodType,
                    ImageUrl = entity.ImageUrl
                };

        public static RecipeEntity MapDetailModelToEntity(RecipeDetailModel model)
        => model == null
            ? null
            : new()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                FoodType = model.FoodType,
                ImageUrl = model.ImageUrl,
                Ingredients = model.Ingredients.Select(model => IngredientAmountMapper.MapDetailModelToEntity(model)).ToList()
            };
    }
}