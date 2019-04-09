using System;
using System.Collections.Generic;
using System.Text;
using CookBook.BL.Repositories;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTestsFixture
    {
        private readonly IIngredientRepository repository;

        public IngredientRepositoryTestsFixture()
        {
            repository = new IngredientRepository(new InMemoryDbContextFactory());
        }

        public IIngredientRepository Repository => repository;

    }
}
