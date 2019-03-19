using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalculatorTest
    {
        private MockUserInterface userInterface;
        private CalculatorService calculator;

        [TestInitialize]
        public void SetUp()
        {
            userInterface = new MockUserInterface();

            // This is integration test, if we understand Mathematics as part of our "Suit under test".
            // It also should be Mocked, because it is already tested.
            calculator = new CalculatorService(new Mathematics(), userInterface);
        }

        [TestMethod]
        public void FiveAddFive_WritesToOutput_10()
        {
            Calculate(5, 10, Commands.add);
        }

        [TestMethod]
        public void FiveMinus_WritesToOutput_Zero()
        {
            Calculate(5, 0, Commands.sub);
        }

        [TestMethod]
        public void FiveMultipleFive_WritesToOutput_25()
        {
            Calculate(5, 25, Commands.mul);
        }

        private void Calculate(int first, int second, Commands command)
        {
            userInterface.Setup(first, second, command);
            calculator.Run();
            userInterface.Verify();  
        }

        [ExpectedException(typeof(InvalidOperationException), "Unknown command has to stop the app")]
        [TestMethod]
        public void UnknownCommand_Throws_InvalidOperationException()
        {
            // max. integer is valid enum value, because Commands are int.
            // configured input and expected numbers are irelevant, because the exception is thrown before we use them.
            userInterface.Setup(5, 10, (Commands)int.MaxValue);
            calculator.Run();
        }
    }
}
