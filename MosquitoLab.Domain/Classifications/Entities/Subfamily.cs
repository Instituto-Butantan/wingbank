using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Subfamily")]
    public class Subfamily : CommonEntityWithKey
    {
        [Key]
        public string SubfamilyName { get; set; }
        public int FamilyId { get; set; }
        public int TaxonomicClassificationId { get; set; }
    }
}
