using System.Threading;
using Xunit;

namespace ParallelProgramming.Samples.Synchronization
{
    public class SynchronizationIssuesSample
    {
        private class Counter
        {
            private int Count { get; set; }

            public void Increment()
            {
                //Critical section
                var count = Count + 1;
                Count = count;
                //End of critical section
            }

            public int GetCount()
            {
                return Count;
            }
        }

        [Fact]
        public void ThreadPoolReadWriteSample()
        {
            var counter = new Counter();

            for (var i = 0; i < 40; i++)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    counter.Increment();
                });
            }

            Thread.Sleep(10000);
            Assert.Equal(40, counter.GetCount());
        }
    }
}