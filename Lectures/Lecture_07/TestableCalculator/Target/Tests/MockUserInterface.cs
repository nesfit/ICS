using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// Fake user interface implementation, to avoid user interaction in automated unit tests.
	/// Usually you will use e.g. Moq library to reduce writing such helper classes.
    /// </summary>
    internal class MockUserInterface : IUserInterface
    {
        // simplified fake input, we return always the same number, never mind how many times asked
        private int input;
        private int expectedResult;
        private int result;
        private Commands command;

        internal void Verify()
        {
            Assert.AreEqual(expectedResult, result, "Parsed input wasnt correctly calculated");
        }

        public void WriteOutput(int result)
        {
            this.result = result;
        }

        public int ParseInput()
        {
            return input;
        }

        public Commands ParseCommand()
        {
            return command;
        }

        /// <summary>
        /// Allows configure the fake user interface with required values.
        /// </summary>
        public void Setup(int input, int expectedResult, Commands command)
        {
            this.input = input;
            this.expectedResult = expectedResult;
            this.command = command;
        }
    }
}