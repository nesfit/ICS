namespace Calculators.Engine
{
    public interface IUserInterface
    {
        MathematicModel ReadModel();
        void WriteResult(int result);
    }
}