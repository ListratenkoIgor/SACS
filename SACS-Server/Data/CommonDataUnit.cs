using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SACS_Server.Data
{
    public class CommonDataUnit : IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private bool _disposed = false;
        public CommonDataUnit(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDbContext.Dispose();
                }
                _disposed = true;
            }
        }

        ~CommonDataUnit()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
