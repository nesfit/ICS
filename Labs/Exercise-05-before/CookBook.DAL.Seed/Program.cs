using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace CookBook.DAL.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = CreateDbContext())
            {
                ClearDatabase(dbContext);
                SeedData(dbContext);
            }
        }

        private static void SeedData(CookBookDbContext dbContext)
        {
            var darkChocolate = new IngredientEntity
            {
                Id = new Guid("5abdfee1-c970-4afd-aff8-aa3cfef8b1ac"),
                Name = "Tmavá čokoláda",
                Description = "Tmavá čokoláda s 80% kakaa.",
            };
            dbContext.Ingredients.Add(darkChocolate);

            var wholeMilk = new IngredientEntity
            {
                Id = new Guid("83041385-cb60-401b-bf11-cc5ffb8bc570"),
                Name = "Plnotučné mlieko",
                Description = "Plnotučné mlieko so 4% tuku.",
            };
            dbContext.Ingredients.Add(wholeMilk);

            var almondFlour = new IngredientEntity
            {
                Id = new Guid("cb181669-4e02-449f-bf02-ab6020dfecb4"),
                Name = "Mandlová múka",
                Description = "Najemno umletá mandlová múka",
            };
            dbContext.Ingredients.Add(almondFlour);

            var egg = new IngredientEntity
            {
                Id = new Guid("012ac89a-94e3-4bc2-94b5-c9b05fc83375"),
                Name = "Vajíčko",
                Description = "Slepačie vajíčko.",
            };
            dbContext.Ingredients.Add(egg);

            dbContext.Recipes.Add(
                new RecipeEntity
                {
                    Id = new Guid("cb8db9b3-799c-4ef2-9d85-ce32a9ffa843"),
                    Name = "Čokoládová torta",
                    Duration = TimeSpan.FromMinutes(30),
                    FoodType = FoodType.Dessert,
                    Ingredients =
                    {
                        new IngredientAmountEntity
                        {
                            Id = new Guid("1d2e7873-3e35-4d40-877c-a3d0d78de3c0"),
                            Amount = 0.5,
                            Unit = Unit.Kg,
                            Ingredient = darkChocolate
                        },
                        new IngredientAmountEntity
                        {
                            Id = new Guid("2711f535-3566-446c-9ac6-58261efe3fa3"),
                            Amount = 0.3,
                            Unit = Unit.L,
                            Ingredient = wholeMilk
                        },
                        new IngredientAmountEntity
                        {
                            Id = new Guid("c8cdbff9-6692-42ad-93aa-69cb56f95019"),
                            Amount = 5,
                            Unit = Unit.Pieces,
                            Ingredient = egg
                        },
                        new IngredientAmountEntity
                        {
                            Id = new Guid("b417ad46-b94c-487e-8cc1-97ebd7551b13"),
                            Amount = 7,
                            Unit = Unit.Spoon,
                            Ingredient = almondFlour
                        }
                    }
                });
            dbContext.SaveChanges();
        }

        private static void ClearDatabase(CookBookDbContext dbContext)
        {
            dbContext.RemoveRange(dbContext.IngredientAmountEntities);
            dbContext.RemoveRange(dbContext.Recipes);
            dbContext.RemoveRange(dbContext.Ingredients);
            dbContext.SaveChanges();
        }

        private static CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}
