using CookBook.BL.Interfaces;
using CookBook.BL.Repositories;
using CookBook.DAL.Tests;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTestsFixture : CookBookDbContextSetupFixture
    {
        public IngredientRepositoryTestsFixture() : base(nameof(IngredientRepositoryTestsFixture)) => Repository = new IngredientRepository(DbContextFactory);

        public IIngredientRepository Repository { get; }
    }
}
