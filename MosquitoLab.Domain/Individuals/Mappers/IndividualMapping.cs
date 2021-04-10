using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dapper.FluentMap.Dommel.Mapping;
using MosquitoLab.Domain.Individuals.Entities;

namespace MosquitoLab.Domain.Individuals.Mappers
{
    public class IndividualMapping 
    {
        public static void Initialize()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new IndividualMap());
                config.AddMap(new InternalControlMap());
                config.AddMap(new WingImageMap());
                config.ForDommel();
            });
        }

        public class IndividualMap : DommelEntityMap<Individual>
        {
            public IndividualMap()
            {
                ToTable("Individual");
                Map(p => p.Id).IsKey();
            }
        }

        public class InternalControlMap : DommelEntityMap<InternalControl>
        {
            public InternalControlMap()
            {
                ToTable("InternalControl");
                Map(p => p.IndividualId).IsKey();
            }
        }

        public class WingImageMap : DommelEntityMap<WingImage>
        {
            public WingImageMap()
            {
                ToTable("WingImage");
                Map(p => p.Id).IsKey();
            }
        }
    }
}
