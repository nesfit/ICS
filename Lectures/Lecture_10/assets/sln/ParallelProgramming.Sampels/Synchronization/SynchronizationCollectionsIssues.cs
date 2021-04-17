using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParallelProgramming.Samples.Synchronization
{
    public class SynchronizationCollectionsIssues
    {
        [Fact]
        public void SynchronizationCollectionIssues()
        {
            var source = Enumerable.Range(1, 420).ToList();
            var destination = new List<int>();

            Parallel.ForEach(source,
                n => { destination.Add(n); });

            Assert.Equal(source.Count, destination.Count);
        }

        [Fact]
        public void SynchronizationCollectionSolution()
        {
            var source = Enumerable.Range(1, 420).ToList();
            var destination = new BlockingCollection<int>();

            Parallel.ForEach(source,
                n => { destination.Add(n); });

            Assert.Equal(source.Count, destination.Count);
        }
    }
}