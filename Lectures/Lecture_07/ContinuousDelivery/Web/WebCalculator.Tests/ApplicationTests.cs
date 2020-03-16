using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebCalculator.Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        // probably make port configurable
        private const int port = 42014;

        private ChromeDriver browser;
        private Process serverProcess;

        [SetUp]
        public void BeforeScenario()
        {
            // the path shouldnt count with project structure
            const string serverName = @"..\..\..\Release\Web\netcoreapp3.1\WebCalculator.exe";
            var exePath = TestContext.CurrentContext.WorkDirectory;
            var fullPath = Path.Combine(exePath, serverName);
            // we handle application orchestration here, which isn't usually part of the E2E test
            var startInfo = new ProcessStartInfo(fullPath, string.Empty);
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            this.serverProcess = Process.Start(startInfo);

            this.browser = new ChromeDriver();
            this.browser.Navigate().GoToUrl("http://localhost:" + port);
        }

        [TearDown]
        public void AfterScenario()
        {
            if (this.serverProcess != null)
            {
                this.serverProcess.Kill();
                this.serverProcess.WaitForExit(1000);
                TestContext.WriteLine(this.serverProcess.StandardOutput.ReadToEnd());
                TestContext.WriteLine(this.serverProcess.StandardError.ReadToEnd());
                this.serverProcess.Dispose();
            }

            if (this.browser != null)
                this.browser.Dispose();
        }

        [Test]
        public void ShowsCalcultedResult()
        { 
            IWebElement firstField = this.browser.FindElementById("First");
            firstField.SendKeys(50.ToString());
            IWebElement secondField = this.browser.FindElementById("Second");
            secondField.SendKeys(20.ToString());
            IWebElement btnCalculate = this.browser.FindElementById("btnCalculate");
            btnCalculate.Click();
            var pageSource = this.browser.PageSource;
            bool containsReusltText = pageSource.Contains("Calculation result is:");
            Assert.IsTrue(containsReusltText, "The calculated value wasn't presented on result screen.");
        }
    }
}
