using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("TaxonomicClassification")]
    public class TaxonomicClassification : CommonEntityWithKey
    {
        public string ClassificationType { get; set; }
    }
}
