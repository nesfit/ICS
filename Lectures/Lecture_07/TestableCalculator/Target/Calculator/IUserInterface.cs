namespace Calculator
{
    internal interface IUserInterface
    {
        /// <summary>
        /// Present calculated number to the user
        /// </summary>
        void WriteOutput(int result);

        /// <summary>
        /// Ask user to provide number as a calculation input parameter.
        /// </summary>
        int ParseInput();
        
        /// <summary>
        /// Asks user to provide required mathematical operation on input numbers.
        /// </summary>
        Commands ParseCommand();
    }
}