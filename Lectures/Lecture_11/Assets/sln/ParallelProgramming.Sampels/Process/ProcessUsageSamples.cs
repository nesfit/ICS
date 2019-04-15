using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.Process
{
    public class ProcessUsageSamples
    {
        public ProcessUsageSamples(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly ITestOutputHelper output;

        private int lineNumber;

        private void OnOsProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data)) output.WriteLine($"[{lineNumber++}]{e.Data}");
        }

        [Fact]
        public void OpeningFileViaProcess()
        {
            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName =
                    @"c:\Development\Lectures\FIT\ParallelProgramming\Assets\sln\ParallelProgramming.Sampels\Test.txt";
                process.StartInfo.UseShellExecute = true;

                process.Start();

                process.WaitForExit(5000);

                if (process.HasExited == false) process.Kill();
            }
        }

        [Fact]
        public void RunningOsProcess()
        {
            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "ping";
                process.StartInfo.Arguments = "8.8.8.8";

                process.StartInfo.RedirectStandardOutput = true;

                process.OutputDataReceived += OnOsProcessOutputDataReceived;

                process.Start();

                process.BeginOutputReadLine();

                process.WaitForExit();
            }
        }
    }
}