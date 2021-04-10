using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;
using MosquitoLab.Domain.Individuals.Enums;

namespace MosquitoLab.Domain.Individuals.Entities
{
    [Table("Individual")]
    public class Individual : CommonEntityWithKey
    {
        public int OriginId { get; set; }
        public int TaxonomicClassificationId { get; set; }
        public int? ClassificationMethodologyId { get; set; }
        public int? ClassificationPersonResponsibleId { get; set; }
        public Gender Gender { get; set; }
        public string DonationOriginalCode { get; set; }
        public string TempLabCode { get; set; }
        public int? TempId { get; set; }
    }
}
