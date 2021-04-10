using System;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Classifications.Entities
{
    [Table("Origin")]
    public class Origin :  CommonEntityWithKey
    {
        public int? ColonyId { get; private set; }
        public int? FieldSamplingId { get; private set; }
        public int? DonorInstitutionId { get; private set; }
        public DateTime? DonationDatetime { get; private set; }
        public string TempLabCode { get; private set; }
    }
}
