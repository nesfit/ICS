using System.Linq;
using Xunit;

namespace Tests.Linq.Gotchas
{
    public class LinqProviderBoundaryTest
    {
        [Fact]
        public void Queryable_StoresExpressionTree()
        {
            IQueryable<int> query = new[] { 1, 2, 3, 4 }
                .AsQueryable()
                .Where(n => n > 2);

            Assert.Contains("Where", query.Expression.ToString());
            Assert.IsAssignableFrom<IQueryable<int>>(query);
        }

        [Fact]
        public void AsEnumerable_SwitchesToInMemoryOperators()
        {
            IQueryable<int> queryable = new[] { 1, 2, 3, 4 }.AsQueryable();

            var afterBoundary = queryable
                .Where(n => n > 1)
                .AsEnumerable()
                .Where(IsEven);

            Assert.Equal(new[] { 2, 4 }, afterBoundary.ToArray());
            Assert.False(afterBoundary is IQueryable<int>);
        }

        private static bool IsEven(int n) => n % 2 == 0;
    }
}
