using System;
using System.Text;

namespace WeakReferenceExample
{
    internal class Program
    {
        /// <summary>
        /// Ukazatel na data, které můžou být kdykoli smazány
        /// </summary>
        private static WeakReference weak;

        private static void Main()
        {
            weak = new WeakReference(new StringBuilder("Hello word!"));

            TryWeakReference();

            MakeGarbage();

            TryWeakReference();
        }

        private static void TryWeakReference()
        {
            if (weak.IsAlive)
            {
                //MakeGarbage();
                Console.WriteLine("Objekt přežil. {0}", (weak.Target as StringBuilder));
            }
            else
            {
                Console.WriteLine("Objekt už není v paměti.");
            }
        }

        private static void MakeGarbage()
        {
            //GC.Collect();
            for (int i = 0; i < 1000000; i++)
            {
                var newStringBuilder = new StringBuilder();
                newStringBuilder.Append("Some text");
            }
        }
    }
}