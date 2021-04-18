using System;
using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds
{
    public static class RecipeSeeds
    {
        public static RecipeEntity RecipeEntity = new()
        {
            Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
            Name = "Recipe seeded recipe 1",
            Description = "Recipe seeded recipe 1 description",
            Duration = TimeSpan.FromHours(2),
            FoodType = FoodType.MainDish
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>().HasData(new
            {
                RecipeEntity.Id,
                RecipeEntity.Name,
                RecipeEntity.Description,
                RecipeEntity.Duration,
                RecipeEntity.FoodType
            });
        }


        static RecipeSeeds()
        {
            RecipeEntity.Ingredients = new[]
            {
                IngredientAmountSeeds.IngredientAmountEntity1, IngredientAmountSeeds.IngredientAmountEntity2
            };
        }
    }
}