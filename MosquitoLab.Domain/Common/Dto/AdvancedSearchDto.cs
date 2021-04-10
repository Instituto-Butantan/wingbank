using System.Collections.Generic;
using MosquitoLab.Domain.Classifications.Entities;

namespace MosquitoLab.Domain.Common.Dto
{
    public class AdvancedSearchDto
    {
        public IList<Family> Families { get; set; }
        public IList<Genus> Genus { get; set; }
        public IList<Species> Species { get; set; }
        public IList<Tribe> Tribes { get; set; }
    }
}
