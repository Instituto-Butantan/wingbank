using System.Collections.Generic;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Application.Common.Services.Interfaces
{
    public interface IAppService <TEntity> where TEntity : CommonEntityWithKey
    {
        /// <summary>
        /// The get method returns a record of the database whose primary key is equal to the id parameter
        /// </summary>
        /// <param name="id"></param>
        TEntity Get(object id);


        /// <summary>
        /// The get method all, retrieves all the records from the databases of a common entity
        /// </summary>
        /// <returns>all the records from the databases of a common entity</returns>
        IList<TEntity> GetAll();

        /// <summary>
        /// The add method adds a common entity to the database
        /// </summary>
        /// <param name="entity"> The add method adds a common entity to the database</param>
        void Add(TEntity entity);

        /// <summary>
        /// The add method update a common entity to the database
        /// </summary>
        /// <param name="entity"> The add method adds a common entity to the database</param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        /// The add method delete a common entity to the database
        /// </summary>
        /// <param name="entity"> The add method adds a common entity to the database</param>
        /// <returns></returns>
        bool Delete(TEntity entity);
    }
}
