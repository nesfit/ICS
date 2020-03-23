using CookBook.BL.Models;
using Xunit;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTests : IClassFixture<IngredientRepositoryTestsFixture>
    {
        private readonly IngredientRepositoryTestsFixture fixture;

        public IngredientRepositoryTests(IngredientRepositoryTestsFixture fixture)
        {
            this.fixture = fixture;
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
    }
}