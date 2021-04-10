using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Subgenus")]
    public class Subgenus : CommonEntityWithKey
    {
        [Key]
        public string SubgenericName { get; set; }
        public int GenusId { get; set; }
        public int TaxonomicClassificationId { get; set; }
    }
}
