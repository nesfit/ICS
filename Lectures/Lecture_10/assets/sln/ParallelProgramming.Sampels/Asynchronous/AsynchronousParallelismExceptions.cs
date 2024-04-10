using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.Asynchronous
{
    public class AsynchronousParallelismExceptions
    {
        private readonly ITestOutputHelper output;

        public AsynchronousParallelismExceptions(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly SemaphoreSlim testOutputSemaphore = new(1);

        private Task ThrowExceptionAsync()
        {
            throw new Exception("Bum!");
        }


        [Fact]
        public async Task CatchAsyncExceptions()
        {
            await Assert.ThrowsAsync<Exception>(async () => await ThrowExceptionAsync());
        }
        
        [Fact]
        public void CatchAsyncExceptions_ThrowsSynchronously()
        {
            Task task = null;
            try
            {
                task = ThrowExceptionAsync();
            }
            catch (Exception e)
            {
                // skip
                // this is not what you expect
            }
            
            Assert.Null(task);
        }
        
        [Fact]
        public async Task CatchAsyncExceptions_ThrowsAsyncSynchronously()
        {
            var task = Task.Run(ThrowExceptionAsync);
            await Assert.ThrowsAsync<Exception>(async () => await task);
        }
    }
}
