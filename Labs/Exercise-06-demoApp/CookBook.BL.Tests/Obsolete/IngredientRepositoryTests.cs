using System;
using CookBook.BL.Models;
using Xunit;

namespace CookBook.BL.Tests.Obsolete
{
    public class IngredientRepositoryObsoleteTests : IClassFixture<IngredientRepositoryObsoleteTestsFixture>, IDisposable
    {
        private readonly IngredientRepositoryObsoleteTestsFixture fixture;

        public IngredientRepositoryObsoleteTests(IngredientRepositoryObsoleteTestsFixture fixture)
        {
            this.fixture = fixture;

            this.fixture.PrepareDatabase();
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var model = new IngredientDetailModel
            {
                Description = "Testovací ingredience",
                Name = "Ingredience 1"
            };

            var returnedModel = fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            fixture.Repository.Delete(returnedModel.Id);
        }

        public void Dispose()
        {
            fixture.TearDownDatabase();
        }
    }
}