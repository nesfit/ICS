using CookBook.BL.Repositories.Obsolete;
using CookBook.DAL.Tests;

namespace CookBook.BL.Tests.Obsolete
{
    public class IngredientRepositoryObsoleteTestsFixture : CookBookDbContextSetupFixture
    {
        public IngredientRepositoryObsoleteTestsFixture() : base(nameof(IngredientRepositoryObsoleteTestsFixture)) => Repository = new IngredientRepositoryObsolete(base.DbContextFactory);

        public IngredientRepositoryObsolete Repository { get; }
    }
}
