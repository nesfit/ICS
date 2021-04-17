using System.Threading;
using Xunit;

namespace ParallelProgramming.Samples.Synchronization
{
    public class SynchronizationFixedSample
    {
        private class SemaphoredCounter
        {
            private readonly SemaphoreSlim counterAddSemaphore = new SemaphoreSlim(1);

            private int Count { get; set; }

            public void Increment()
            {
                counterAddSemaphore.Wait();
                try
                {
                    //Critical section
                    var count = Count + 1;
                    Count = count;
                    //End of critical section
                }
                finally
                {
                    counterAddSemaphore.Release();
                }
            }

            public int GetCount()
            {
                return Count;
            }
        }


        private class LockedCounter
        {
            private readonly object incrementMethodLockHandle = new object();
            private int Count { get; set; }

            public void Increment()
            {
                lock (incrementMethodLockHandle)
                {
                    //Critical section
                    var count = Count + 1;
                    Count = count;
                    //End of critical section
                }
            }

            public int GetCount()
            {
                return Count;
            }
        }

        [Fact]
        public void LockLockedThreadPoolReadWriteSample()
        {
            var counter = new LockedCounter();

            for (var i = 0; i < 40; i++)
                ThreadPool.QueueUserWorkItem(state => { counter.Increment(); });
            Thread.Sleep(10000);
            Assert.Equal(40, counter.GetCount());
        }

        [Fact]
        public void SemaphoreLockedThreadPoolReadWriteSample()
        {
            var counter = new SemaphoredCounter();

            for (var i = 0; i < 40; i++)
                ThreadPool.QueueUserWorkItem(state => { counter.Increment(); });
            Thread.Sleep(10000);
            Assert.Equal(40, counter.GetCount());
        }
    }
}