using System;
using CookBook.BL.Repositories.Obsolete;
using CookBook.DAL.Tests;

namespace CookBook.BL.Tests.Obsolete
{
    [Obsolete]
    public class RecipeRepositoryObsoleteTestsFixture : CookBookDbContextSetupFixture
    {
        public RecipeRepositoryObsoleteTestsFixture() : base(nameof(RecipeRepositoryObsoleteTestsFixture))
        {

            Repository = new RecipeRepositoryObsolete(base.DbContextFactory);

            this.PrepareDatabase();
        }
        
        public RecipeRepositoryObsolete Repository { get; }
    }
}