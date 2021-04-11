using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dapper.FluentMap.Dommel.Mapping;
using MosquitoLab.Domain.Classifications.Entities;

namespace MosquitoLab.Domain.Classifications.Mappers
{
    public class ClassificationMapping 
    {
        public static void Initialize()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new FamilyMap());
                config.ForDommel();
            });
        }

        public class FamilyMap : DommelEntityMap<Family>
        {
            public FamilyMap()
            {
                ToTable("Family");
                Map(p => p.FamilyName).IsKey();
            }
        }
    }
}
