using Microsoft.AspNetCore.Mvc;
using Calculators.Engine;
using NUnit.Framework;
using WebCalculator.Controllers;

namespace WebCalculator.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private readonly HomeController controller = new HomeController();

        [Test]
        public void Open_Index_UsesEmptyModel()
        {
            var viewResult = this.controller.Index() as ViewResult;
            const string message = "The initial model is used to render default values";
            Assert.IsInstanceOf(typeof(MathematicModel), viewResult.Model, message);
        }

        [Test]
        public void PostedValidModel_Calculate_RendersResult()
        {
            var input = new MathematicModel()
            {
                First = 5,
                Second = 2
            };
            var viewResult = this.controller.Calculate(input) as ViewResult;
            const string message = "The calculated result should be delivered as model to the view";
            Assert.IsInstanceOf(typeof(int), viewResult.Model, message);
        }
    }
}
