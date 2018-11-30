using DGQ.Infrustructure.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;

namespace DGQ.Infrustructure.EF
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private DbTransaction dbTransaction = null;

        public EFUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IUnitOfWork BeginTransaction()
        {
            _context.Database.BeginTransaction();
            dbTransaction = _context.Database.CurrentTransaction.GetDbTransaction();
            return this;
        }

        public void CommitTransaction()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void Dispose()
        {
            if (dbTransaction != null)
            {
                this.dbTransaction.Dispose();
            }
            this._context.Dispose();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
