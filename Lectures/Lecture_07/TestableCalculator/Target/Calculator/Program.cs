namespace Calculator
{
    // inspired by : http://channel9.msdn.com/blogs/mtaulty/prism--silverlight-part-1-taking-sketched-code-towards-unity
    internal class Program
    {
        private static void Main()
        {
            var calculator = new CalculatorService(new Mathematics(), new UserInterface());
            calculator.Run();
        }
    }
}
