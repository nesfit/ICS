using System;
using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds
{
    public static class Seeds
    {
        public static readonly IngredientEntity Water = new IngredientEntity()
        {
            Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"),
            Name = "Water",
            Description = "Mineral water"
        };

        public static RecipeEntity RecipeEntity = new RecipeEntity
        {
            Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
            Name = "Recipe seeded recipe 1",
            Description = "Recipe seeded recipe 1 description",
            Duration = TimeSpan.FromHours(2),
            FoodType = FoodType.MainDish
        };

        public static IngredientEntity IngredientEntity1 = new IngredientEntity
        {
            Id = Guid.Parse("df935095-8709-4040-a2bb-b6f97cb416dc"),
            Name = "Ingredient seeded ingredient 1",
            Description = "Ingredient seeded ingredient 1 description"
        };

        public static IngredientEntity IngredientEntity2 = new IngredientEntity
        {
            Id = Guid.Parse("23b3902d-7d4f-4213-9cf0-112348f56238"),
            Name = "Ingredient seeded ingredient 2",
            Description = "Ingredient seeded ingredient 2 description"
        };

        public static IngredientAmountEntity IngredientAmountEntity1 = new IngredientAmountEntity
        {
            Id = Guid.Parse("0d4fa150-ad80-4d46-a511-4c666166ec5e"),
            Amount = 1.0,
            Unit = Unit.Kg,
            Recipe = RecipeEntity,
            Ingredient = IngredientEntity1
        };

        public static IngredientAmountEntity IngredientAmountEntity2 = new IngredientAmountEntity
        {
            Id = Guid.Parse("87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
            Amount = 2.0,
            Unit = Unit.L,
            Recipe = RecipeEntity,
            Ingredient = IngredientEntity2
        };


        static Seeds() => RecipeEntity.Ingredients = new[] {IngredientAmountEntity1, IngredientAmountEntity2};

        
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(new
            {
                IngredientEntity1.Id,
                IngredientEntity1.Name,
                IngredientEntity1.Description
            }, new
            {
                IngredientEntity2.Id,
                IngredientEntity2.Name,
                IngredientEntity2.Description
            },
                Water);

            modelBuilder.Entity<IngredientAmountEntity>().HasData(
                new
                {
                    IngredientAmountEntity1.Id,
                    IngredientAmountEntity1.Amount,
                    IngredientAmountEntity1.Unit,
                    IngredientId = IngredientEntity1.Id,
                    RecipeId = RecipeEntity.Id
                },
                new
                {
                    IngredientAmountEntity2.Id,
                    IngredientAmountEntity2.Amount,
                    IngredientAmountEntity2.Unit,
                    IngredientId = IngredientEntity2.Id,
                    RecipeId = RecipeEntity.Id
                }
            );

            modelBuilder.Entity<RecipeEntity>().HasData(new
            {
                RecipeEntity.Id,
                RecipeEntity.Name,
                RecipeEntity.Description,
                RecipeEntity.Duration,
                RecipeEntity.FoodType,
            });
        }
    }
}