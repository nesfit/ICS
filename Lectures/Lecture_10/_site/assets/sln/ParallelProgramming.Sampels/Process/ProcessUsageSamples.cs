using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.Process
{
    public class ProcessUsageSamples
    {
        private readonly ITestOutputHelper output;

        private int lineNumber;

        public ProcessUsageSamples(ITestOutputHelper output)
        {
            this.output = output;
        }

        private void OnOsProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data)) output.WriteLine($"[{lineNumber++}]{e.Data}");
        }

        [Fact]
        public void OpeningFileViaProcess()
        {
            using var process = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    FileName = @"Test.txt", 
                    UseShellExecute = true
                }
            };

            process.Start();

            process.WaitForExit(5000);

            if (process.HasExited == false) process.Kill();
        }

        [Fact]
        public void RunningOsProcess()
        {
            using var process = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    FileName = "ping", 
                    Arguments = "8.8.8.8", 
                    RedirectStandardOutput = true
                }
            };


            process.OutputDataReceived += OnOsProcessOutputDataReceived;

            process.Start();

            process.BeginOutputReadLine();

            process.WaitForExit();
        }
    }
}