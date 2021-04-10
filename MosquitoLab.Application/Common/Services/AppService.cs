using System.Collections.Generic;
using MosquitoLab.Application.Common.Services.Interfaces;
using MosquitoLab.Domain.Common.Entities;
using MosquitoLab.Domain.Common.Repositories;
using MosquitoLab.Domain.Persistence.Context;

namespace MosquitoLab.Application.Common.Services
{
    public class AppService<TEntity> : IAppService<TEntity> where TEntity : CommonEntityWithKey
    {
        protected IRepository<TEntity> Repository;
        protected IUnitOfWork UnitOfWork;

        public AppService(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public virtual TEntity Get(object id)
        {
            throw new System.NotImplementedException();
        }

        public virtual IList<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual void Add(TEntity entity)
        {
            Repository.Add(entity);
        }

        public virtual bool Update(TEntity entity)
        {
            return Repository.Update(entity);
        }

        public virtual bool Delete(TEntity entity)
        {
            return Repository.Delete(entity);
        }
    }
}
