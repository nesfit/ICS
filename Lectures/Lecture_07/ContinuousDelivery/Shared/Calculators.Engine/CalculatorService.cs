namespace Calculators.Engine
{
    public class CalculatorService
    {
        private readonly IUserInterface userInterface;

        public CalculatorService(IUserInterface userInterface)
        {
            //
            this.userInterface = userInterface;
        }

        public void Run()
        {
            MathematicModel model = this.userInterface.ReadModel();
            int result = Calculate(model);
            this.userInterface.WriteResult(result);
        }

        private static int Calculate(MathematicModel model)
        {
            switch (model.Operation)
            {
                default:
                    return Mathematics.Add(model.First, model.Second);
            }
        }
    }
}
