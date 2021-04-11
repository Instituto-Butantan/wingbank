using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Tribe")]
    public class Tribe : CommonEntityWithKey
    {
        public string TribeName { get; set; }
        public int FamilyId { get; set; }
        public int TaxonomicClassificationId { get; set; }
    }
}
