namespace Exercise_3.MathExercise
{
    public interface IMathOperation
    {
        char Operand { get; }
        string OperationName { get; }
        int GetCorrectResult(int leftOperand, int rightOperand);
    }
}