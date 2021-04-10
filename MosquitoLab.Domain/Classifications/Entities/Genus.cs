using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Genus")]
    public class Genus : CommonEntityWithKey
    {
        [Key]
        public string GenericName { get; set; }
        public int TribeId { get; set; }
        public int SubfamilyId { get; set; }
        public int TaxonomicClassificationId { get; set; }
    }
}
