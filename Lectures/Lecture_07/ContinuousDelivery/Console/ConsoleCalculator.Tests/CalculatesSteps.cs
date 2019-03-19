using System.Diagnostics;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using TestStack.White;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace ConsoleCalculator.Tests
{
    [Binding]
    public class CalculatesSteps
    {
        private Application calculator;
        private Window window;
        private string consoleOutput = string.Empty;

        [BeforeScenario]
        public void BeforeScenario()
        {
            var startInfo = new ProcessStartInfo("ConsoleCalculator.exe")
            {
                UseShellExecute = false, // needed to redirect the output
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            };
           this.calculator = Application.Launch(startInfo);
           this.window = this.calculator.GetWindows().First();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.window.Dispose();
            this.window = null;
            this.calculator.Close();
            this.calculator.Dispose();
            this.calculator = null;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            this.window.Keyboard.Enter(number.ToString());
            this.window.KeyIn(KeyboardInput.SpecialKeys.RETURN);
        }

        [When(@"I press any key")]
        public void WhenIPressAnyKey()
        {
            this.window.KeyIn(KeyboardInput.SpecialKeys.RETURN);
            var process = this.calculator.Process;
            this.consoleOutput = process.StandardOutput.ReadToEnd();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int number)
        {
            bool outputContainsResult = this.consoleOutput.Contains("Result is: 7");
            Assert.IsTrue(outputContainsResult, "The calculated value wasnt reported to the console: " + this.consoleOutput);
        }
    }
}
