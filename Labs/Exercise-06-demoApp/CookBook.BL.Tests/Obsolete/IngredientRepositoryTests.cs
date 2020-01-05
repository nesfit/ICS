using System;
using CookBook.BL.Models;
using Xunit;

namespace CookBook.BL.Tests.Obsolete
{
    public class IngredientRepositoryObsoleteTests : IClassFixture<IngredientRepositoryObsoleteTestsFixture>, IDisposable
    {
        private readonly IngredientRepositoryObsoleteTestsFixture _fixture;

        public IngredientRepositoryObsoleteTests(IngredientRepositoryObsoleteTestsFixture fixture)
        {
            this._fixture = fixture;

            this._fixture.PrepareDatabase();
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var model = new IngredientDetailModel
            {
                Description = "Testovací ingredience",
                Name = "Ingredience 1"
            };

            var returnedModel = _fixture.Repository.Create(model);

            Assert.NotNull(returnedModel);

            _fixture.Repository.Delete(returnedModel.Id);
        }

        public void Dispose()
        {
            _fixture.TearDownDatabase();
        }
    }
}