using Calculators.Engine;
using NUnit.Framework;

namespace Calculator.Engine.Tests
{
    [TestFixture]
    public class MathematicsTests
    {
        [Test]
        public void FiveTwo_Add_ReturnsSeven()
        {
            int current = Mathematics.Add(5, 2);
            Assert.AreEqual(7, current, "the mathematic operation add should add first number to second.");
        }
    }
}
