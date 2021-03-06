﻿using CookBook.DAL.Entities;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<IngredientAmountEntity> IngredientAmountEntities { get; set; } = null!;
        public DbSet<RecipeEntity> Recipes { get; set; } = null!;
        public DbSet<IngredientEntity> Ingredients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>()
                .HasMany(i => i.Ingredients)
                .WithOne(i => i.Recipe!)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IngredientEntity>()
                .HasMany<IngredientAmountEntity>()
                .WithOne(i => i.Ingredient!)
                .OnDelete(DeleteBehavior.Restrict);

            IngredientSeeds.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
