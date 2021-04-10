using System.Data;
using MosquitoLab.Domain.Persistence.Context;

namespace MosquitoLab.Infra.Persistence.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDbContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Transaction = null;
            Context?.Connection?.Close();
            Context?.Dispose();
        }

        public IDbContext Context { get; private set; }

        public IDbConnection Connection => Context.Connection;

        public IDbTransaction Transaction { get; private set; }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            return Transaction ?? (Transaction = Context.Connection.BeginTransaction(isolationLevel));
        }

        public void Rollback()
        {
            Transaction?.Rollback();
            Dispose();
        }

        public void Commit()
        {
            Transaction?.Commit();
            Dispose();
        }
    }
}
