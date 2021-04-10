using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using MosquitoLab.Domain.Accounts.Filters;
using MosquitoLab.Domain.Classifications.Dto;
using MosquitoLab.Domain.Classifications.Entities;
using MosquitoLab.Domain.Classifications.Repositories;
using MosquitoLab.Domain.Persistence.Context;
using MosquitoLab.Infra.Common.Repositories;

namespace MosquitoLab.Infra.Classifications.Repositories
{
    public class SubfamilyRepository : Repository<Subfamily>, ISubfamilyRepository
    {
        public SubfamilyRepository(IDbContext context) : base(context)
        {
        }

        public IList<SimpleSelectDto> All(AdancedSearchFilter filter)
        {
            using (Connection)
            {
                var query = new StringBuilder();
                query.Append(@"
                    select
	                    e.Id as  'Id',
	                    e.SubfamilyName as 'Name'
                    from
	                    Subfamily e
                    where
	                    @FamilyId is null or e.FamilyId =  @FamilyId
                    ORDER BY 
	                    e.SubfamilyName asc;
                ");
                return Connection.Query<SimpleSelectDto>(query.ToString()
                    , filter).ToList();
            }
        }
    }
}
