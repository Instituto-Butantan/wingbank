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
    public class GenusRepository : Repository<Genus>, IGenusRepository
    {
        public GenusRepository(IDbContext context) : base(context)
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
	                    e.GenericName as 'Name'
                    from
	                    Genus e
	                    inner join Subfamily sf on sf.Id = e.SubfamilyId
	                    inner join Family f on f.Id = sf.FamilyId
                    where
	                    f.Id =  @FamilyId
	                    and e.TribeId =  @TribeId
                        or (@TribeId is null and (sf.Id  = @SubfamilyId))

                    ORDER BY 
	                    Name asc;
                ");
                return Connection.Query<SimpleSelectDto>(query.ToString(), filter).ToList();
            }
        }
    }
}
