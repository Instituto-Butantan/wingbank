using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using MosquitoLab.Domain.Common.Entities;
using MosquitoLab.Domain.Common.Repositories;
using MosquitoLab.Domain.Persistence.Context;
using Dommel;
using Serilog;

namespace MosquitoLab.Infra.Common.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : CommonEntityWithKey
    {
        private string Error => "Generic Repository error: ";

        protected IDbConnection Connection { get; set; }

        internal IDbContext Context;

        public Repository(IDbContext context)
        {
            if (Context == null)
                Context = context;

            Connection = Context.Connection;

        }

        public void Dispose()
        {
            Connection?.Close();
            Connection?.Dispose();
            Context?.Dispose();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> @where)
        {
            using (Connection)
            {
                return Connection.Get<TEntity>(@where);
            }
        }

        public virtual IList<TEntity> Query(Expression<Func<TEntity, bool>> @where)
        {
            using (Connection)
            {
                return Connection.Select(@where).ToList();
            }
        }

        public virtual IList<TEntity> GetAll()
        {
            using (Connection)
            {
                try
                {
                    return Connection.GetAll<TEntity>().ToList();
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e, $"{Error} get all entities ");
                    throw;
                }
            }
        }

        public virtual void Add(TEntity entity, IDbTransaction transaction = null)
        {
            using (Connection)
            {
                try
                {
                    Connection = transaction == null ? Connection : transaction.Connection;
                    Connection.Insert(entity, transaction);
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e,
                        $"{Error} saving entity - {entity.GetType().FullName} : {entity} CreatedAt: {DateTime.Now} ");
                    throw;
                }
            }

        }

        public virtual bool Update(TEntity entity, IDbTransaction transaction = null)
        {
            using (Connection)
            {
                try
                {
                    Connection = transaction == null ? Connection : transaction.Connection;
                    return Connection.Update(entity, transaction);
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e,
                        $"{Error} update entity - {entity.GetType().FullName} : {entity} CreatedAt: {DateTime.Now} ");
                    throw;
                }
            }

        }

        public virtual bool Delete(TEntity entity, IDbTransaction transaction = null)
        {
            using (Connection)
            {
                try
                {
                    Connection = transaction == null ? Connection : transaction.Connection;
                    return Connection.Update(entity, transaction);
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e,
                        $"{Error} update entity - {entity.GetType().FullName} : {entity} CreatedAt: {DateTime.Now} ");
                    throw;
                }
            }

        }
    }
}
