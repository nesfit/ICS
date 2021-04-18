using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CookBook.DAL.Seeds
{
    public class IngredientSeeds
    {
        public static readonly IngredientEntity Water =
            new()
            {
                Id = Guid.Parse("818f1def-204e-44da-b764-ca28c75e2acc"),
                Name = "Water",
                Description = "Mineral Water",
                ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
            };

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(Water);
        }
    }
}