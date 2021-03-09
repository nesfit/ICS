using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Lock
    {
        private readonly object _thisLock = new object();

        private int _increment = 0;
        private async Task CriticalSection()
        {
            await Task.Delay(16);

            lock (_thisLock)
            {
                _increment++;
            }
        }

        [Fact]
        private async Task Test()
        {
            var attempts = 1_000_000;
            var tasks = 
                Enumerable.Range(1, attempts)
                .Select(_ => Task.Run(CriticalSection));
            
            await Task.WhenAll(tasks);

            Assert.Equal(attempts, _increment);
        }
    }
}