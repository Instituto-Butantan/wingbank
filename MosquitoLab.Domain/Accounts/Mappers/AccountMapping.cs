using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dapper.FluentMap.Dommel.Mapping;
using MosquitoLab.Domain.Accounts.Entities;

namespace MosquitoLab.Domain.Accounts.Mappers
{
    public class AccountMapping
    {
        public static void Initialize()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserMap());
                config.ForDommel();
            });
        }

        public class UserMap : DommelEntityMap<User>
        {
            public UserMap()
            {
                ToTable("User");
                Map(p => p.Id).IsKey();
            }
        }
    }
}
