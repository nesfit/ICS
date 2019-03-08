using System.Collections.Generic;
using Exercise_3.MathExercise;

namespace Exercise_3
{
    class MathExercisersProgram
    {
        private readonly List<IMathOperation> mathExercises = new List<IMathOperation>
        {
            new AdditionMathOperation(),
            new SubtractionMathOperation(),
            new MultiplicationMathOperation()
        };

        public void Run()
        {
            var consoleHelper = new ConsoleHelper();
            var mathExerciseRunner = new MathExerciseRunner(consoleHelper, consoleHelper);
            foreach (var mathExercise in mathExercises)
            {
                mathExerciseRunner.Test(mathExercise);
            }
        }
    }
}