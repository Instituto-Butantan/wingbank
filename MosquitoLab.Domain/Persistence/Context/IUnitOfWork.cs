using System;
using System.Data;

namespace MosquitoLab.Domain.Persistence.Context
{
    public interface IUnitOfWork : IDisposable 
    {
        /// <summary>
        /// Current Context Database
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// Current Transaction Context
        /// </summary>
        IDbTransaction Transaction { get; }

        /// <summary>
        /// Begin a new context transaction with isolation level
        /// </summary>
        /// <param name="isolationLevel">System.Data.IsolateLevel</param>
        /// <returns> Return a  new context Transaction</returns>
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);

        /// <summary>
        /// Rollback the changes in current transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Commit the changes made in current transaction
        /// </summary>
        void Commit();

    }
}
