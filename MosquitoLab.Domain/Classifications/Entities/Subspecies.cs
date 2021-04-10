using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Subspecies")]
    public class Subspecies : CommonEntityWithKey
    {
        public int SpeciesId { get; set; }
        public string SubspeciesName { get; set; }
        public int TaxonomicClassificationId { get; set; }
    }
}
