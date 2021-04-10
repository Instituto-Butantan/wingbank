using System.Data;
using Dapper;
using MosquitoLab.Domain.Common.Dto;
using MosquitoLab.Domain.Common.Repositories;
using MosquitoLab.Domain.Persistence.Context;

namespace MosquitoLab.Infra.Common.Repositories
{
    public class DatabaseInfoRepository : IDatabaseInfoRepository
    {

        private string Error => "Repository error: ";

        protected IDbConnection Connection { get; set; }

        internal IDbContext Context;
        public DatabaseInfoRepository(IDbContext context)
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
        public DatabaseInfoDto GetDatabaseInfo()
        {
            const string query = @"
         select
	         (
		        select COUNT(Id) FROM WingImage WHERE ImageFile IS NOT NULL
	        ) as 'Records'
	        ,(
		        select 
		          COUNT(DISTINCT wi.Id)
		        from
			        WingImage wi
			        inner join WingPublication wp on wp.WingImageId = wi.Id 
			        inner join Individual i on i.Id  =  wi.IndividualId
			        inner join TaxonomicClassification tc on i.TaxonomicClassificationId = tc.Id
			        inner join Origin o on o.Id  =  i.OriginId
                where
                    wi.ImageFile IS NOT NULL
	        ) as 'AvailableRecords';       
            ";
            using (Connection)
            {
                return Connection.QueryFirstOrDefault<DatabaseInfoDto>(query);
            }
        }
    }
}
