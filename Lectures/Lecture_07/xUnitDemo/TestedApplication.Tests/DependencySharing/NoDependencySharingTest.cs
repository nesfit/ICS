using System;
using TestedApplication.Tests.DependencySharing.Fixtures;
using Xunit;

namespace TestedApplication.Tests.DependencySharing
{
    public class NoDependencySharingTest : IDisposable
    {
        private readonly NonSharedFixture nonSharedFixture;

        public NoDependencySharingTest()
        {
            nonSharedFixture = new NonSharedFixture();
        }

        [Fact]
        public void ParameterLessTest()
        {
            //ARRANGE
            var first = 5;
            var second = 6;

            //ACT
            var result = first + second;

            //ASSERT
            Assert.Equal(11, result);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 2, Skip = "This test is skipped.")]
        public void TestWithParameters(int first, int second, int expectedResult)
        {
            //ARRANGE


            //ACT
            var result = first + second;

            //ASSERT
            Assert.Equal(expectedResult, result);
        }

        public void Dispose()
        {
            nonSharedFixture?.Dispose();
        }
    }
}