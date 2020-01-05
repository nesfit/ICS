using System;
using CookBook.BL.Models;
using Xunit;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTests : IClassFixture<IngredientRepositoryTestsFixture>, IDisposable
    {
        private readonly IngredientRepositoryTestsFixture _fixture;

        public IngredientRepositoryTests(IngredientRepositoryTestsFixture fixture)
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

            var returnedModel = _fixture.Repository.InsertOrUpdate(model);

            Assert.NotNull(returnedModel);

            _fixture.Repository.Delete(returnedModel.Id);
        }

        public void Dispose()
        {
            _fixture.TearDownDatabase();
        }
    }
}