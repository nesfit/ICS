using System;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds
{
    public static class IngredientSeeds
    {
        public static readonly IngredientEntity Water = new()
        {
            Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"),
            Name = "Water",
            Description = "Mineral water",
            ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
        };


        public static IngredientEntity IngredientEntity1 = new()
        {
            Id = Guid.Parse("df935095-8709-4040-a2bb-b6f97cb416dc"),
            Name = "Ingredient seeded ingredient 1",
            Description = "Ingredient seeded ingredient 1 description"
        };

        public static IngredientEntity IngredientEntity2 = new()
        {
            Id = Guid.Parse("23b3902d-7d4f-4213-9cf0-112348f56238"),
            Name = "Ingredient seeded ingredient 2",
            Description = "Ingredient seeded ingredient 2 description"
        };

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
        }
    }
}