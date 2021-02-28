using System;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds
{
    public static class IngredientSeed
    {
        public static readonly IngredientEntity Water = new(
        Guid.Parse("818f1def-204e-44da-b764-ca28c75e2acc"),
        "Water",
        "Mineral");

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(Water);
        }
    }
}