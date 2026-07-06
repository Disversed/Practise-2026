using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_MemoryManagement
{
    internal class MemoryEater : IDisposable
    {
        static private long _10MB = 10 * 1024 * 1024;

        private byte[] arr;
        private bool disposed;

        public long AllocatedMemory
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(nameof(MemoryEater));
                return arr.LongLength;
            }
        }

        public MemoryEater() : this(_10MB) { }

        public MemoryEater(long memoryToAllocate)
        {
            arr = new byte[memoryToAllocate];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            
            if (disposing)
            {
                if (arr != null) arr = null;
            }

            // Unmanaged resources must be disposed here

            disposed = true;
        }

        ~MemoryEater()
        {
            Dispose(false);
        }
    }
}
