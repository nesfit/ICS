using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.Process
{
    public class ProcessUsageSamples(ITestOutputHelper output)
    {
        private int _lineNumber;

        private void OnOsProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data)) output.WriteLine($"[{_lineNumber++}]{e.Data}");
        }

        [Fact]
        public void OpeningFileViaProcess()
        {
            using System.Diagnostics.Process process = new()
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
            using System.Diagnostics.Process process = new()
            {
                StartInfo =
                {
                    FileName = "ping", 
                    Arguments = "-c 4 8.8.8.8", 
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