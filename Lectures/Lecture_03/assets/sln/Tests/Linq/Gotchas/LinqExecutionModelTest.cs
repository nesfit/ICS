using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Linq.Gotchas
{
    public class LinqExecutionModelTest
    {
        [Fact]
        public void DeferredExecution_SeesSourceChangesUntilMaterialized()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var query = numbers.Where(n => n > 1);

            numbers.Add(4);
            Assert.Equal(new[] { 2, 3, 4 }, query.ToArray());

            var snapshot = query.ToList();
            numbers.Add(5);

            Assert.Equal(new[] { 2, 3, 4 }, snapshot);
            Assert.Equal(new[] { 2, 3, 4, 5 }, query.ToArray());
        }

        [Fact]
        public void EnumeratingTwice_ReexecutesPipeline()
        {
            var source = new[] { 1, 2, 3 };
            var selectorRuns = 0;

            var query = source.Select(n =>
            {
                selectorRuns++;
                return n * 10;
            });

            _ = query.ToList();
            _ = query.ToList();

            Assert.Equal(6, selectorRuns);
        }
    }
}
