using System;
using System.Runtime;

namespace IDisposableExample
{
    ///http://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx
    public class DisposableClass : IDisposable
    {
        private bool disposed;

        ~DisposableClass()
        {
            //while (true);
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Test()
        {
            Console.WriteLine(disposed ? "Byl jsem zničen" : "Ještě žiju!");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // cleanup of managed resources
                }

                disposed = true;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            DisposableClass disposableClass;
            using (disposableClass = new DisposableClass())
            {
                disposableClass.Test();
            }

        }
    }
}