using System;

namespace Exercise_3
{
    public class ConsoleHelper : INumberReader, ITextWriter
    {
        public int ReadNumber(string message)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out var input))
            {
                return ReadNumber(message);
            }
            return input;
        }

        public void Write(string message, MessageType type = MessageType.Normal)
        {
            var previouslyForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = GetMessageColor(type);
            Console.WriteLine(message);
            Console.ForegroundColor = previouslyForegroundColor;
        }

        private static ConsoleColor GetMessageColor(MessageType type)
        {
            switch (type)
            {
                case MessageType.Success:
                    return ConsoleColor.Green;
                case MessageType.Fail:
                    return ConsoleColor.Red;
                case MessageType.Normal:
                default:
                    return Console.ForegroundColor;
            }
        }
    }
}