using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("ClassificationMethodology")]
    public class ClassificationMethodology
    {
        public string ClassificationMethod { get; set; }
        public string Reference { get; set; }
    }
}
