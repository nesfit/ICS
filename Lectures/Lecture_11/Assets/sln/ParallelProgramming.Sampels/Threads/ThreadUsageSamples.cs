using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.Threads
{
    public class ThreadUsageSamples
    {
        public ThreadUsageSamples(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly ITestOutputHelper output;


        private void PrintCurrentThreadInfo()
        {
            var th = Thread.CurrentThread;
            output.WriteLine("Managed thread #{0}: ", th.ManagedThreadId);
            output.WriteLine("   Background thread: {0}", th.IsBackground);
            output.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread);
            output.WriteLine("   Priority: {0}", th.Priority);
            output.WriteLine("   Culture: {0}", th.CurrentCulture.Name);
            output.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name);
        }

        [Fact]
        public void CreateThreadAndThenJoinIt()
        {
            var createdThread = new Thread(() =>
            {
                output.WriteLine("New thread started");
                PrintCurrentThreadInfo();
                Thread.Sleep(500);
                output.WriteLine("New thread finishing");
            });

            output.WriteLine("Original thread");
            PrintCurrentThreadInfo();
            createdThread.Start();

            output.WriteLine("Waiting for created thread to finish");

            createdThread.Join();
        }
    }
}