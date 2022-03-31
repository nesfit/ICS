using System;
using TestedApplication.Tests.DependencySharing.Fixtures;
using Xunit;

namespace TestedApplication.Tests.DependencySharing
{
    public class ClassDependencySharingTest1 : IDisposable, IClassFixture<ClassSharedFixture>
    {
        private readonly ClassSharedFixture _classSharedFixture;
        private readonly NonSharedFixture _nonSharedFixture;

        public ClassDependencySharingTest1(ClassSharedFixture classSharedFixture)
        {
            _classSharedFixture = classSharedFixture;
            _nonSharedFixture = new NonSharedFixture();
        }
        [Fact()]
        public void ParameterLessTest()
        {
            //ARRANGE
            int first = 5;
            int second = 6;
            
            //ACT
            var result = first + second;

            //ASSERT
            Assert.Equal(11,result);
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,1,2,Skip = "This test is skipped.")]
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
            _nonSharedFixture?.Dispose();
        }
    }


    public class ClassDependencySharingTest2 : IDisposable, IClassFixture<ClassSharedFixture>
    {
        private readonly ClassSharedFixture _classSharedFixture;
        private readonly NonSharedFixture _nonSharedFixture;

        public ClassDependencySharingTest2(ClassSharedFixture classSharedFixture)
        {
            _classSharedFixture = classSharedFixture;
            _nonSharedFixture = new NonSharedFixture();
        }
        [Fact()]
        public void ParameterLessTest()
        {
            //ARRANGE
            int first = 5;
            int second = 6;
            
            //ACT
            var result = first + second;

            //ASSERT
            Assert.Equal(11,result);
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,1,2,Skip = "This test is skipped.")]
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
            _nonSharedFixture?.Dispose();
        }
    }


}
