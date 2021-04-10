using System.Collections.Generic;
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
    public class SubspeciesRepository : Repository<Subspecies>, ISubspeciesRepository
    {
        public SubspeciesRepository(IDbContext context) : base(context)
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
	                    e.SubspeciesName as 'Name'
                    from
	                    Subspecies e
                    where
	                   (@SpecieId is null or e.SpeciesId = @SpecieId)
                    ORDER BY 
	                    e.SubspeciesName asc;
                ");
                return Connection.Query<SimpleSelectDto>(query.ToString(), filter).ToList();
            }
        }
    }
}
