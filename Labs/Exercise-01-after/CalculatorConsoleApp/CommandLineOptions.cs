using System;
using CommandLine;
using Exercise_01.CalculatorUtils;

namespace Exercise_01.CalculatorConsoleApp
{
    /// <summary>
    ///     CommandLine parser settings
    ///     https://commandline.codeplex.com/
    /// </summary>
    internal class CommandLineOptions
    {
        [Option('f', "first", Required = false, HelpText = "The first operand.")]
        public Int32? First { get; set; }

        [Option('o', "operation", Required = true, HelpText = "The operation.")]
        public MathOperation Operation { get; set; }

        [Option('s', "second", Required = false, HelpText = "The second operand.")]
        public Int32? Second { get; set; }

        [Option('v', "verbose", Default = false, HelpText = "Prints all messages to standard output.")]
        public Boolean Verbose { get; set; }
    }
}