using System.Threading;
using Xunit;

namespace ParallelProgramming.Samples.Synchronization
{
    public class SynchronizationIssuesSample
    {
        private class Counter
        {
            public int Count { get; private set; } = 0;

            public void Increment()
            {
                //Critical section
                var count = Count + 1;
                Count = count;
                //End of critical section
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

            Thread.Sleep(500); //Very naive waiting for ThreadPool schedule threads, please do not use this in production!
            Assert.Equal(40, counter.Count);
        }
    }
}