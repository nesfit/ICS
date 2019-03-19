using Calculators.Engine;
using Moq;
using NUnit.Framework;

namespace Calculator.Engine.Tests
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        [Test]
        public void FiveTwo_Calculate_WritesSevenToUi()
        {
            var model = new MathematicModel()
            {
                First = 5, 
                Second = 2
            };

            var userInterfaceMock = new Mock<IUserInterface>();
            userInterfaceMock.Setup(c => c.ReadModel())
                .Returns(model);
            userInterfaceMock.Setup(c => c.WriteResult(7))
                .Verifiable("output of add operation should be written to the ui");

            var calculator = new CalculatorService(userInterfaceMock.Object);
            calculator.Run();
            userInterfaceMock.VerifyAll();
        }
    }
}
