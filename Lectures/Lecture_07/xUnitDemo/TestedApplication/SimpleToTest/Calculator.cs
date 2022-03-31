using System;
using TestedApplication.Database;

namespace TestedApplication.SimpleToTest
{
    public class Calculator
    {
        public int Calculate(Operations command, int first, int second)
        {
            switch (command)
            {
                case Operations.Add:
                    return Add(first, second);
                case Operations.Sub:
                    return Sub(first, second);
                default:
                    throw new InvalidOperationException("The command is not supported.");
            }
        }

        private int Sub(int first, int second)
        {
            checked
            {
                return first - second;
            }
        }

        private int Add(int first, int second)
        {
            checked
            {
                return first + second;
            }
        }
    }
}
