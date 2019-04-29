using System;

namespace IDisposableExample
{
    public class DisposableClass
    {
        private bool disposed = false;

        ~AnObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // cleanup of managed resources } // cleanup of unmanaged resources }
                }

                this.disposed = true;
            }
        }
    }
}