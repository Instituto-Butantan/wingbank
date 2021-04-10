using MosquitoLab.Domain.Accounts.Mappers;
using MosquitoLab.Domain.Classifications.Mappers;
using MosquitoLab.Domain.Individuals.Mappers;

namespace MosquitoLab.Bootstrap.FluentMapping
{
    public class FluentMapping
    {
        public static void Initialize()
        {
            IndividualMapping.Initialize();
            AccountMapping.Initialize();
            ClassificationMapping.Initialize();
        }
    }
}
