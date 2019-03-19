using Calculators.Engine;

namespace WebCalculator.Models
{
    public class Calculator: IUserInterface
    {
        private int result;
        private readonly MathematicModel model;

        public Calculator(MathematicModel model)
        {
            this.model = model;
        }

        public MathematicModel ReadModel()
        {
            return this.model;
        }

        public void WriteResult(int result)
        {
            this.result = result;
        }

        internal int Calculate()
        {
            var calculator = new CalculatorService(this);
            calculator.Run();
            return this.result;
        }
    }
}