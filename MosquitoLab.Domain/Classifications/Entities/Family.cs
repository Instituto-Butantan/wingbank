using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Family")]
    public class Family : CommonEntityWithKey
    {
        [Key]
        public string FamilyName { get; set; }
        public string TaxonomicClassificationId { get; set; }
    }
}
