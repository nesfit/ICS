using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParallelProgramming.Samples.Synchronization
{
    public class SynchronizationCollectionsIssues
    {
        private readonly List<int> _source = Enumerable.Range(1, 420).ToList();

        [Fact]
        public void SynchronizationCollectionIssues()
        {
            var destination = new List<int>();

            Parallel.ForEach(_source,
                n => { destination.Add(n); });

            // Equal should be expected
            Assert.NotEqual(_source.Count, destination.Count);
        }

        [Fact]
        public void SynchronizationCollectionSolution()
        {
            var destination = new BlockingCollection<int>();

            Parallel.ForEach(_source,
                n => { destination.Add(n); });

            Assert.Equal(_source.Count, destination.Count);
        }
    }
}