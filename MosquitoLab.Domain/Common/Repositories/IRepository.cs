using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Common.Repositories
{
    /// <summary>
    /// This is a generic repository interface.
    /// </summary>
    /// <typeparam name="TEntity"> A generic entity with characteristics of a common entity is spelled as a parameter </typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : CommonEntityWithKey
    {

        /// <summary>
        /// The get method returns a record of the database whose primary key is equal to the id parameter
        /// </summary>
        /// <param name="where"></param>
        TEntity Get(Expression<Func<TEntity, bool>> @where);

        /// <summary>
        /// The Query method return one list with linq expression results
        /// </summary>
        /// <param name="where"> linq  expressino </param>
        /// <returns> return  List<TEntity/>  </returns>
        IList<TEntity> Query(Expression<Func<TEntity, bool>> @where);

        /// <summary>
        /// The get method all, retrieves all the records from the databases of a common entity
        /// </summary>
        /// <returns>all the records from the databases of a common entity</returns>
        IList<TEntity> GetAll();

        /// <summary>
        /// The add method adds a common entity to the database
        /// </summary>
        /// <param name="entity"> The add method adds a common entity to the database</param>
        /// <param name="transaction">The open transaction in the context, if it is in a scope of a transaction it is necessary to pass this parameter</param>
        void Add(TEntity entity, IDbTransaction transaction = null);

        /// <summary>
        /// The add method update a common entity to the database
        /// </summary>
        /// <param name="entity"> The add method adds a common entity to the database</param>
        /// <param name="transaction">The open transaction in the context, if it is in a scope of a transaction it is necessary to pass this parameter</param>
        /// <returns></returns>
        bool Update(TEntity entity, IDbTransaction transaction = null);

        /// <summary>
        /// The add method delete a common entity to the database
        /// </summary>
        /// <param name="entity"> The add method adds a common entity to the database</param>
        /// <param name="transaction">The open transaction in the context, if it is in a scope of a transaction it is necessary to pass this parameter</param>
        /// <returns></returns>
        bool Delete(TEntity entity, IDbTransaction transaction = null);
    }
}
