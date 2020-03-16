using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace ConsoleCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Process process;

        [Test]
        public void Five_Add2_WritesOutputToConsole()
        {
            this.StartApplication();

            var input = this.process.StandardInput;
            input.WriteLine("5");
            input.WriteLine("2");
            input.WriteLine("add");

            var resultStream = this.process.StandardOutput;
            var result = resultStream.ReadToEnd();
            process.WaitForExit(5000);
            
            bool outputContainsResult = result.Contains("Result is: 7");
            Assert.IsTrue(outputContainsResult, "The calculated value wasn't reported to the console:\r\n" + result);
        }

        private void StartApplication()
        {
            var assemblyPath = typeof(CalculatorTests).Assembly.Location;
            string consoleExe = Path.Combine(Path.GetDirectoryName(assemblyPath), @"..\..\netcoreapp3.1\ConsoleCalculator.exe");
            var startInfo = new ProcessStartInfo(consoleExe)
            {
                UseShellExecute = false, // needed to redirect the output
                // cant redirect outputs, otherwise the Automation is unable to mange the app.
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            this.process = Process.Start(startInfo);
        }
    }
}
