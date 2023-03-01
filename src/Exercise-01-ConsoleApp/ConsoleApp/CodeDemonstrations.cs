using System;
using Calculator.Utils;

namespace Exercise_01.ConsoleApp;

internal static class CodeDemonstrations
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
    ///     Runs for loop, note: has to be static if we want to call it from Main.
    /// </summary>
    public static void RunForLoop()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"For: {i}");
        }
    }

    /// <summary>
    ///     Runs while loop, note: has to be static if we want to call it from Main.
    /// </summary>
    public static void RunWhileLoop()
    {
        int index = 0;

        while (index < 11)
        {
            index++;
            Console.WriteLine($"Do - while: {index}");
        }
    }

    /// <summary>
    ///     Shows if branching, note: has to be static if we want to call it from Main.
    /// </summary>
    public static void ShowIf(int condition)
    {
        // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
        if (condition > 3)
        {
            Console.WriteLine("condition is greater than 3");
        }
        else
        {
            Console.WriteLine("condition is not greater than 3");
        }
    }

    /// <summary>
    ///     Calculates basic mathematical operations (+,-,*,/) on given operands using
    ///     mathematical assembly implemented by students themselves.
    ///     Writes the result to console.
    /// </summary>
    public static void Calculate()
    {
        const int operand1 = 1;
        const int operand2 = 2;
        int sum = Calculator.Utils.Calculator.Calculate(operand1, operand2, MathOperation.Addition);
        Console.WriteLine($"{operand1}+{operand2}={sum}");
    }

    /// <summary>
    ///     Gets input from keyboard, note: has to be static if we want to call it from Main.
    /// </summary>
    public static void GetInput()
    {
        try
        {
            Console.WriteLine("Waiting for input (number)...");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Input: {input}");
        }
        catch (FormatException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw new ApplicationException("Upsss....");
        }
        finally
        {
            // executes always, after the try and/or catch
            Console.WriteLine("Release resources... cleaning after myself");
        }
    }
}
