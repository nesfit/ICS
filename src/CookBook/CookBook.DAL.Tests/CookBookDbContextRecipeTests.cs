using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CookBook.Common.Enums;
using CookBook.Common.Tests;
using CookBook.DAL.Entities;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextRecipeTests : CookBookDbContextTestsBase
    {
        public CookBookDbContextRecipeTests(ITestOutputHelper output) : base(output)
        {
        }
        
        [Fact]
        public async Task AddNew_RecipeWithoutIngredients_Persisted()
        {
            //Arrange
            RecipeEntity entity = new()
            {
                Name = "Chicken soup",
                Description = "Grandma's delicious chicken soup."
            };

            //Act
            CookBookDbContextSUT.Recipes.Add(entity);
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = DbContextFactory.CreateDbContext();
            var actualEntity = await dbx.Recipes
                .SingleAsync(i => i.Id == entity.Id);
            DeepAssert.Equal(entity, actualEntity);
        }

        // Adding ingredients alongside with recipe could be considered a bad design because ingredients are strong entities
        [Fact]
        public async Task AddNew_RecipeWithIngredients_Persisted()
        {
            //Arrange
            RecipeEntity entity = new()
            {
                Name = "Lemonade",
                Description = "Simple lemon lemonade",
                Ingredients =
                {
                    new IngredientAmountEntity
                    {
                        Amount = 1,
                        Unit = Unit.L,
                        Ingredient = new()
                        {
                            Name = "Water",
                            Description = "Filtered Water",
                            ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
                        }
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 50,
                        Unit = Unit.Ml,
                        Ingredient = new()
                        {
                            Name = "Lime-juice",
                            Description = "Fresh lime-juice",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Lime-Whole-Split.jpg/640px-Lime-Whole-Split.jpg"
                        }
                    }
                }
            };

            //Act
            CookBookDbContextSUT.Recipes.Add(entity);
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = DbContextFactory.CreateDbContext();
            var actualEntity = await dbx.Recipes
                .Include(i => i.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .SingleAsync(i => i.Id == entity.Id);
            DeepAssert.Equal(entity, actualEntity);
        }

        // Adding ingredientAmounts alongside with recipe is OK because ingredientAmounts are not strong entities
        [Fact]
        public async Task AddNew_RecipeWithJustIngredientAmounts_Persisted()
        {
            //Arrange
            RecipeEntity entity = new()
            {
                Name = "Lemonade",
                Description = "Simple lemon lemonade",
                Ingredients =
                {
                    new IngredientAmountEntity
                    {
                        Amount = 1,
                        Unit = Unit.L,
                        IngredientId = IngredientSeeds.IngredientEntity1.Id
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 50,
                        Unit = Unit.Ml,
                        IngredientId = IngredientSeeds.IngredientEntity2.Id
                    }
                }
            };

            //Act
            CookBookDbContextSUT.Recipes.Add(entity);
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = DbContextFactory.CreateDbContext();
            var actualEntity = await dbx.Recipes
                .Include(i => i.Ingredients)
                .SingleAsync(i => i.Id == entity.Id);
            DeepAssert.Equal(entity, actualEntity);
        }

        [Fact]
        public async Task GetById_Recipe()
        {
            //Act
            var entity = await CookBookDbContextSUT.Recipes
                .SingleAsync(i => i.Id == RecipeSeeds.RecipeEntity.Id);

            //Assert
            DeepAssert.Equal(RecipeSeeds.RecipeEntity with {Ingredients = Array.Empty<IngredientAmountEntity>() }, entity);
        }

        [Fact]
        public async Task GetById_IncludingIngredients_Recipe()
        {
            //Act
            var entity = await CookBookDbContextSUT.Recipes
                .Include(i=>i.Ingredients)
                .ThenInclude(i=>i.Ingredient)
                .SingleAsync(i => i.Id == RecipeSeeds.RecipeEntity.Id);

            //Assert
            DeepAssert.Equal(RecipeSeeds.RecipeEntity, entity);
        }

        [Fact]
        public async Task Update_Recipe_Persisted()
        {
            //Arrange
            var baseEntity = RecipeSeeds.RecipeEntityUpdate;
            var entity =
                baseEntity with
                {
                    Name = baseEntity.Name + "Updated",
                    Description = baseEntity.Description + "Updated",
                    Duration = TimeSpan.MaxValue,
                    FoodType = FoodType.None,
                    ImageUrl = baseEntity.ImageUrl +"Updated",
                };

            //Act
            CookBookDbContextSUT.Recipes.Update(entity);
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = DbContextFactory.CreateDbContext();
            var actualEntity = await dbx.Recipes.SingleAsync(i => i.Id == entity.Id);
            DeepAssert.Equal(entity, actualEntity);
        }

        [Fact]
        public async Task Delete_IngredientAmount_Deleted()
        {
            //Arrange
            var baseEntity = RecipeSeeds.RecipeEntityDelete;

            //Act
            CookBookDbContextSUT.Recipes.Remove(baseEntity);
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            Assert.False(await CookBookDbContextSUT.Recipes.AnyAsync(i => i.Id == baseEntity.Id));
        }

        [Fact]
        public async Task DeleteById_IngredientAmount_Deleted()
        {
            //Arrange
            var baseEntity = RecipeSeeds.RecipeEntityDelete;

            //Act
            CookBookDbContextSUT.Remove(
                CookBookDbContextSUT.Recipes.Single(i => i.Id == baseEntity.Id));
            await CookBookDbContextSUT.SaveChangesAsync();

            //Assert
            Assert.False(await CookBookDbContextSUT.Recipes.AnyAsync(i => i.Id == baseEntity.Id));
        }
    }
}
