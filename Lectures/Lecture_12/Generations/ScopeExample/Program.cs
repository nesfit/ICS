using System;
using System.Threading;

namespace ScopeExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string helloWord = "Hello word!";

            if (helloWord == "Hello word!")
            {
                var myClass = new MyClass("test");
                myClass.PrintText();
                Console.WriteLine(GC.GetGeneration(myClass));
            }
            GC.Collect(2);

            Thread.Sleep(10000);
            Console.WriteLine(helloWord);

            Console.ReadLine();
        }
    }

    internal class MyClass
    {
        public MyClass(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }

        ~MyClass()
        {
        }

        public void PrintText()
        {
            Console.WriteLine(Text);
        }
    }
}