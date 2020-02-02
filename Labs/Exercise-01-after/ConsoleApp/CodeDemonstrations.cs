using System;
using Exercise_01.CalculatorUtils;

namespace Exercise_01.ConsoleApp
{
    internal class CodeDemonstrations
    {
        public static void RunAllDemonstrations()
        {
            RunForLoop();

            RunWhileLoop();

            ShowIf(5);

            Calculate();

            GetInput();
        }

        /// <summary>
        ///     Runs for loop, note: has to be static if we want to call it from Main
        /// </summary>
        public static void RunForLoop()
        {
            for (var i = 0; i < 10; i++) Console.WriteLine("For: {0}", i);
        }

        /// <summary>
        ///     Runs while loop, note: has to be static if we want to call it from Main
        /// </summary>
        public static void RunWhileLoop()
        {
            var index = 0;

            while (index < 11)
            {
                index = index + 1;
                Console.WriteLine($"Do - while: {index}");
            }
        }

        /// <summary>
        ///     Shows if branching, note: has to be static if we want to call it from Main
        /// </summary>
        public static void ShowIf(int condition)
        {
            if (condition > 3)
                Console.WriteLine("condition is greater than 3");
            else
                Console.WriteLine("condition is not greater than 3");
        }

        /// <summary>
        ///     Calculates basic mathematical operations (+,-,*,/) on given operands using
        ///     mathematical assembly implemented by students them selves.
        ///     Writes results on console.
        /// </summary>
        public static void Calculate()
        {
            const int operand1 = 1;
            const int operand2 = 2;
            var sum = Calculator.Calculate(operand1, operand2, MathOperation.Addition);
            Console.WriteLine($"{operand1}+{operand2}={sum}");
        }

        /// <summary>
        ///     Gets input from keyboard, note: has to be static if we want to call it from Main
        /// </summary>
        public static void GetInput()
        {
            try
            {
                Console.WriteLine("Waiting for input (number)...");
                var input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input: {0}", input);
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new ApplicationException("HUpsss....");
            }
            finally
            {
                // executes always, after the try and/or catch
                Console.WriteLine("Release resources... cleaning after my self");
            }
        }
    }
}