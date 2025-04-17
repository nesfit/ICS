using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.Threads
{
    public class ThreadPoolSamples(ITestOutputHelper output)
    {
        private void PrintCurrentThreadInfo()
        {
            Thread thread = Thread.CurrentThread;
            output.WriteLine("Managed thread #{0}: ", thread.ManagedThreadId);
            output.WriteLine("   Background thread: {0}", thread.IsBackground);
            output.WriteLine("   Thread pool thread: {0}", thread.IsThreadPoolThread);
            output.WriteLine("   Priority: {0}", thread.Priority);
            output.WriteLine("   Culture: {0}", thread.CurrentCulture.Name);
            output.WriteLine("   UI culture: {0}", thread.CurrentUICulture.Name);
        }

        [Fact]
        public void RunPreviousSampleInThreadPool()
        {
            output.WriteLine("Original thread");
            PrintCurrentThreadInfo();

            ThreadPool.QueueUserWorkItem(state =>
            {
                output.WriteLine("New thread started");
                PrintCurrentThreadInfo();
                Thread.Sleep(500); //Very naive waiting for ThreadPool schedule threads, please do not use this in production!
                output.WriteLine("New thread finishing");
            });

            Thread.Sleep(1000); //Very naive waiting for ThreadPool schedule threads, please do not use this in production!
        }
    }
}