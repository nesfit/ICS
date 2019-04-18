using System;
using System.Collections.Generic;
using System.Text;
using CookBook.BL.Interfaces;
using CookBook.BL.Repositories;
using CookBook.BL.Repositories.Obsolete;
using CookBook.DAL;
using CookBook.DAL.Tests;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTestsFixture : CookBookDbContextSetupFixture
    {
        public IngredientRepositoryTestsFixture() : base(nameof(IngredientRepositoryTestsFixture)) => Repository = new IngredientRepository(base.DbContextFactory);

        public IIngredientRepository Repository { get; }
    }
}
