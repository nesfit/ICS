namespace Exercise_3.MathExercise
{
    class SubtractionMathOperation : IMathOperation
    {
        public char Operand => '-';
        public string OperationName => "odčítání";

        public int GetCorrectResult(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}