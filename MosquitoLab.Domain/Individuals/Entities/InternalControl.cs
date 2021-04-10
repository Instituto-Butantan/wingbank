using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Individuals.Entities
{
    [Table("InternalControl")]
    public class InternalControl : CommonEntity
    {
        [Key]
        public int IndividualId { get; set; }
        public string LabCode { get; set; }
        public string CollectionCode { get; set; }
        public bool IsPublic { get; set; }
        public string TempLabCode { get; set; }
    }
}
