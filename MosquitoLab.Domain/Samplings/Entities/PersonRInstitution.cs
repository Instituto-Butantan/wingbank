using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("PersonRInstitution")]
    public class PersonRInstitution
    {
        [Key]
        public string PersonResponsibleId { get; set; }

        public int InstitutionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

    }
}
