using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MosquitoLab.Domain.Classifications.Dto;
using MosquitoLab.Domain.Classifications.Entities;
using MosquitoLab.Domain.Classifications.Repositories;
using MosquitoLab.Domain.Persistence.Context;
using MosquitoLab.Infra.Common.Repositories;

namespace MosquitoLab.Infra.Classifications.Repositories
{
    public class FamilyRepository : Repository<Family>, IFamilyRepository
    {
        public FamilyRepository(IDbContext context) : base(context)
        {
        }

        public IList<SimpleSelectDto> All()
        {
            using (Connection)
            {
                var query = new StringBuilder();
                query.Append(@"
                    select 
	                     f.Id as Id 
	                    ,f.FamilyName as 'Name'
                    from
	                    Family f
                    order by
	                    f.FamilyName  asc
                ");
                return Connection.Query<SimpleSelectDto>(query.ToString()).ToList();
            }
          
        }
    }
}
