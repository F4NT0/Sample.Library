using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Library
{
    public abstract class AbstractCalculator : ICalculator
    {
        private bool disposedValue;

        public abstract int sum(int a, int b);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                   this.ReleaseResources();
                }

               
                disposedValue = true;
            }
        }


        ~AbstractCalculator()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public abstract void ReleaseResources();
    }
}
