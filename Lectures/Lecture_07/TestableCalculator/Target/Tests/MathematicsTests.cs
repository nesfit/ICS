using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MathematicsTests
    {
        private Mathematics mathematics = new Mathematics();

        [TestMethod]
        public void FivePlusSix_Returns_Eleven()
        {
            int result = mathematics.Add(5, 6);
            Assert.AreEqual(11, result, "Add method has to add second argument to the first");
        }

        [TestMethod]
        public void SixMinusTwo_Returns_Four()
        {
            int result = mathematics.Substract(6, 2);
            Assert.AreEqual(4, result, "Substract method has to substract second number from first");
        }

        [TestMethod]
        public void FiveMultipleTwo_Returns_Ten()
        {
            int result = mathematics.Multiple(6, 2);
            Assert.AreEqual(12, result, "Multiple method has to multiple first number by second");
        }
    }
}
