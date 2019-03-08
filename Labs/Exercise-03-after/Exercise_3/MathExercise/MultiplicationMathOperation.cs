namespace Exercise_3.MathExercise
{
    class MultiplicationMathOperation : IMathOperation
    {
        public char Operand => '*';
        public string OperationName => "násobení";

        public int GetCorrectResult(int leftOperand, int rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}