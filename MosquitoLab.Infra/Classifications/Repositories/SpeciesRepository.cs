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
    public class SpeciesRepository : Repository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(IDbContext context) : base(context)
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
	                    e.SpecificEpithet as 'Name'
                    from
	                    Species e
                    where
                        (@GenusId is null or
	                    e.GenusId =  @GenusId)

                    ORDER BY 
	                    Name asc;

                ");
                return Connection.Query<SimpleSelectDto>(query.ToString()
                    , filter).ToList();
            }
        }
    }
}
