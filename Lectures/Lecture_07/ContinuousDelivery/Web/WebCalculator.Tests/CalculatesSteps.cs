using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace WebCalculator.Tests
{
    [Binding]
    public class CalculatesSteps
    {
        // probably make port configurable
        private const int port = 49703;

        private ChromeDriver browser;
        //private InternetExplorerDriver browser;
        private Process iisProcess;

        [BeforeScenario]
        public void BeforeScenario()
        {
            const string iisExpressPath = @"c:\Program Files (x86)\IIS Express\iisexpress.exe";
            // consider the port to be obtained from AppSettings
            var webAppArguments = BuildIisExpressArguments();
            var iisExpressStart = new ProcessStartInfo(iisExpressPath, webAppArguments);
            this.iisProcess = Process.Start(iisExpressStart);
            this.browser = new ChromeDriver();
            //this.browser = new InternetExplorerDriver();
            this.browser.Navigate().GoToUrl("http://localhost:" + port);
        }

        private static string BuildIisExpressArguments()
        {
            string workingDirectory = TestContext.CurrentContext.WorkDirectory;
            var webPath = Path.Combine(workingDirectory, @"..\..\..\web\WebCalculator\");
            Console.WriteLine("Working directory: " + webPath);
            // iis doesnt like doted path string
            webPath= new DirectoryInfo(webPath).FullName;
            return String.Format(@"/path:{0} /port:{1}", webPath, port);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (this.browser != null)
                this.browser.Dispose();

            if (this.iisProcess != null)
                this.iisProcess.Dispose();
        }

        [Given(@"I have entered (.*) into the first field")]
        public void GivenIHaveEnteredIntoTheFirstField(int number)
        {
            IWebElement firstField = this.browser.FindElementById("First");
            firstField.SendKeys(number.ToString());
        }

        [Given(@"I have entered (.*) into the second field")]
        public void GivenIHaveEnteredIntoTheSecondField(int number)
        {
            IWebElement firstField = this.browser.FindElementById("Second");
            firstField.SendKeys(number.ToString());
        }

        [When(@"I press Calculate")]
        public void WhenIPressCalculate()
        {
            IWebElement btnCalculate = this.browser.FindElementById("btnCalculate");
            btnCalculate.Click();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            bool containsReusltText = this.browser.PageSource.Contains("Calculation result is:");
            Assert.IsTrue(containsReusltText, "The calculated value wasnt presented on result screen.");
        }
    }
}
