using System;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds
{
    public class IngredientSeeds
    {
        public static readonly IngredientEntity Water = new IngredientEntity()
        {
            Id = Guid.Parse("818f1def-204e-44da-b764-ca28c75e2acc"),
            Name = "Water",
            Description = "Mineral"
        };

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(Water);
        }
    }
}