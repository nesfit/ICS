using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextIngredientTests : CookBookDbContextTestsBase
    {
        [Fact]
        public async Task AddNew_Ingredient_Persisted()
        {
            //Arrange
            IngredientEntity ingredientEntity = new(
                Guid.Parse("C5DE45D7-64A0-4E8D-AC7F-BF5CFDFB0EFC"),
                Name : "Salt",
                Description : "Mountain salt",
                ImageUrl : "https://upload.wikimedia.org/wikipedia/commons/thumb/7/78/Salt_shaker_on_white_background.jpg/800px-Salt_shaker_on_white_background.jpg"
            );

            //Act
            CookBookDbContextSUT.Ingredients.Add(ingredientEntity);
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = DbContextFactory.CreateDbContext();
            var retrievedIngredient = await dbx.Ingredients.SingleAsync(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient);
        }

        [Fact]
        public async Task GetAll_Ingredients_ContainsSeededWater()
        {
            var ingredients = await CookBookDbContextSUT.Ingredients.ToArrayAsync();
            Assert.Contains(IngredientSeeds.Water, ingredients);
        }

        [Fact]
        public async Task GetById_Ingredient_WaterRetrieved()
        {
            var ingredient = await CookBookDbContextSUT.Ingredients.SingleAsync(i=>i.Id == IngredientSeeds.Water.Id);
            Assert.Equal(IngredientSeeds.Water, ingredient);
        }

        [Fact]
        public async Task Update_Ingredient_Persisted()
        {
            //Arrange
            var ingredientEntity =
                IngredientSeeds.WaterUpdate with
                {
                    Name = IngredientSeeds.Water.Name + "Updated",
                    Description = IngredientSeeds.Water.Description + "Updated",
                };

            //Act
            CookBookDbContextSUT.Ingredients.Update(ingredientEntity);
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = DbContextFactory.CreateDbContext();
            var retrievedIngredient = await dbx.Ingredients.SingleAsync(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient);
        }

        [Fact]
        public async Task Delete_Ingredient_WaterDeleted()
        {
            CookBookDbContextSUT.Ingredients.Remove(IngredientSeeds.WaterDelete);
            await CookBookDbContextSUT.SaveChangesAsync();

            Assert.False(await CookBookDbContextSUT.Ingredients.AnyAsync(i => i.Id == IngredientSeeds.WaterDelete.Id));
        }

        [Fact]
        public async Task DeleteById_Ingredient_WaterDeleted()
        {
            CookBookDbContextSUT.Remove(
                CookBookDbContextSUT.Ingredients.Single(i => i.Id == IngredientSeeds.WaterDelete.Id));
            await CookBookDbContextSUT.SaveChangesAsync();

            Assert.False(await CookBookDbContextSUT.Ingredients.AnyAsync(i => i.Id == IngredientSeeds.WaterDelete.Id));
        }
    }
}
