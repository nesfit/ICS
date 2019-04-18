using System;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Tests;

namespace CookBook.BL.Tests
{
    public class RecipeRepositoryTestsFixture : CookBookDbContextSetupFixture
    {
        public RecipeRepositoryTestsFixture() : base(nameof(RecipeRepositoryTestsFixture))
        {

            Repository = new RecipeRepository(base.DbContextFactory);

            this.PrepareDatabase();
        }
        
        public RecipeRepository Repository { get; }
    }
}