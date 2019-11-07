using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Context;
using Repository.Domain;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        private Contexto _context = new Contexto();

        private RepositoryBase<Cliente> _clienteRepository;

        public RepositoryBase<Cliente> ClienteRepository
        {
            get
            {
                if (this._clienteRepository == null)
                {
                    this._clienteRepository = new RepositoryBase<Cliente>(_context);
                }

                return _clienteRepository;
            }
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }

        private void Clear(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Clear(false);
        }

    }
}
