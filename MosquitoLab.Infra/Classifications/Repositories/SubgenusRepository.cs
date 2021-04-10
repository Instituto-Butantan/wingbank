using System.Collections.Generic;
using System.Dynamic;
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
    public class SubgenusRepository : Repository<Subgenus>, ISubgenusRepository
    {
        public SubgenusRepository(IDbContext context) : base(context)
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
	                    e.SubgenericName as 'Name'
                    from
	                    Subgenus e
                    where
	                    @GenusId is null or e.GenusId =  @GenusId
                    ORDER BY 
	                    e.SubgenericName asc;

                ");
                return Connection.Query<SimpleSelectDto>(query.ToString(), filter).ToList();
            }
        }
    }
}
