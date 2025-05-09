using System.Threading;
using Xunit;

namespace ParallelProgramming.Samples.Synchronization
{
    public class SynchronizationFixedSample
    {
        private class LockedCounter
        {
            private readonly Lock _incrementMethodLockHandle = new();
            public int Count { get; private set; }

            public void Increment()
            {
                lock (_incrementMethodLockHandle)
                {
                    //Critical section
                    var count = Count + 1;
                    Count = count;
                    //End of critical section
                }
            }
        }

        private class SemaphoredCounter
        {
            private readonly SemaphoreSlim _counterAddSemaphore = new(1);
            public int Count { get; private set; }

            public void Increment()
            {
                _counterAddSemaphore.Wait();
                try
                {
                    //Critical section
                    var count = Count + 1;
                    Count = count;
                    //End of critical section
                }
                finally
                {
                    _counterAddSemaphore.Release();
                }
            }
        }

        [Fact]
        public void LockLockedThreadPoolReadWriteSample()
        {
            LockedCounter counter = new();

            for (var i = 0; i < 40; i++)
                ThreadPool.QueueUserWorkItem(state => { counter.Increment(); });

            Thread.Sleep(500); //Very naive waiting for ThreadPool schedule threads, please do not use this in production!
            Assert.Equal(40, counter.Count);
        }

        [Fact]
        public void SemaphoreLockedThreadPoolReadWriteSample()
        {
            SemaphoredCounter counter = new();

            for (var i = 0; i < 40; i++)
                ThreadPool.QueueUserWorkItem(state => { counter.Increment(); });

            Thread.Sleep(500); //Very naive waiting for ThreadPool schedule threads, please do not use this in production!
            Assert.Equal(40, counter.Count);
        }
    }
}