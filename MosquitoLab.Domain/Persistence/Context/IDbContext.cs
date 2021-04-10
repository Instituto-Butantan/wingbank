using System;
using System.Data;

namespace MosquitoLab.Domain.Persistence.Context
{
    public interface IDbContext : IDisposable 
    {
        /// <summary> 
        /// Database Connection, System.Data;
        /// </summary>
        IDbConnection Connection { get; }
    }
}
