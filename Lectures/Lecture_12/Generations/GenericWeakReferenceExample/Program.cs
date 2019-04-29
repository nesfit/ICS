using System;
using System.Text;

namespace GenericWeakReferenceExample
{
    internal class Program
    {
        private static WeakReference<StringBuilder> weakReference;

        private static void Main(string[] args)
        {
            SetWeakReference();

            TryWeakReference();

            MakeGarbage();

            TryWeakReference();
        }

        private static void TryWeakReference()
        {
            StringBuilder sb;
            if (weakReference.TryGetTarget(out sb))
            {
                Console.WriteLine("Objekt přežil. {0}", sb);
            }
            else
            {
                Console.WriteLine("Objekt už není v paměti.");
            }
        }

        private static void SetWeakReference()
        {
            var sb = new StringBuilder("Hello word!");
            weakReference = new WeakReference<StringBuilder>(sb);
        }

        private static void MakeGarbage()
        {
            //GC.Collect();
            for (int i = 0; i < 100000; i++)
            {
                var newStringBuilder = new StringBuilder();
                newStringBuilder.Append("Some text");
            }
        }
    }
}