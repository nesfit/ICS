using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Lock
    {
        private readonly object _thisLock = new object();

        private int _increment = 0;
        private void CriticalSection()
        {
            lock (_thisLock)
            {
                Task.Delay(16);
                _increment++;
            }
        }

        [Fact]
        private void Test()
        {
            const int attempts = 1_000_000;
            for (var i = 0; i < attempts; i++)
            {
                Task.Run(CriticalSection).ConfigureAwait(false);
            }

            Assert.True(_increment < attempts);
        }
    }
}