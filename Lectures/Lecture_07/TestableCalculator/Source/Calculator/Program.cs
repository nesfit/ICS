using System;

namespace Calculator
{
    internal class Program
    {
	    // inspired by : http://channel9.msdn.com/blogs/mtaulty/prism--silverlight-part-1-taking-sketched-code-towards-unity
		// Tasks:
		// 1. Improve test ability to be able extend the application
		// 2. Add new command for multiplication
		// 3. Change the code so it can be used with Windows phone application User interface
        private static void Main()
        {
			int first = Convert.ToInt32(Console.ReadLine());
			int second = Convert.ToInt32(Console.ReadLine());
			var command = (Commands)Enum.Parse(typeof(Commands), Console.ReadLine());

			switch (command)
			{
				case Commands.add:
					Console.WriteLine(first + second);
					break;
				case Commands.sub:
					Console.WriteLine(first - second);
					break;
				default:
					throw new InvalidOperationException("Unknown command in calculator");
			}

            Console.ReadKey();
        }
    }
}
