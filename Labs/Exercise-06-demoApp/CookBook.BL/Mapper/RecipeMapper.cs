using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CookBook.BL.Mapper
{
    internal static class RecipeMapper
    {
        public static RecipeDetailModel MapToDetailModel(RecipeEntity recipeEntity) =>
            new RecipeDetailModel()
            {
                Id = recipeEntity.Id,
                Name = recipeEntity.Name,
                Description = recipeEntity.Description,
                FoodType = (CookBook.BL.Enums.FoodType)recipeEntity.FoodType,
                Duration = recipeEntity.Duration,
                Ingredients = recipeEntity.Ingredients.Select(IngredientAmountMapper.MapDetailModel).ToList()
            };

        public static RecipeListModel MapToListModel(RecipeEntity recipeEntity) =>
            new RecipeListModel()
            {
                Id = recipeEntity.Id,
                Name = recipeEntity.Name,
                Duration = recipeEntity.Duration,
                FoodType = (CookBook.BL.Enums.FoodType)recipeEntity.FoodType,
            };

        public static RecipeEntity MapToEntity(RecipeDetailModel detailModel)
        {
            var mapToEntity = new RecipeEntity()
            {
                Id = detailModel.Id,
                Name = detailModel.Name,
                Description = detailModel.Description,
                Duration = detailModel.Duration,
                FoodType = (CookBook.DAL.Enums.FoodType) detailModel.FoodType,
                Ingredients = detailModel.Ingredients.Select(IngredientAmountMapper.MapEntity).ToList()
            };

            return mapToEntity;
        }
    }
}