using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Institutions.Entities
{
    [Table("Donation")]
    public class Donation : CommonRelationEntity
    {
        [Key]
        public int InstitutionalId { get; set; }
        public DateTime DonationDateTime { get; set; }
        public int DonationPersonResponsibleId { get; set; }
    }
}
