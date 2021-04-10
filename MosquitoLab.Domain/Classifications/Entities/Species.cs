using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Species")]
    public class Species : CommonEntityWithKey
    {
        [Key]
        public string GenusId { get; set; }
        public int SubgenusId { get; set; }
        public string SpecificEpithet { get; set; }
        public string TaxonomicClassificationId { get; set; }
    }
}
