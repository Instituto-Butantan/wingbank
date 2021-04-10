using System;
using System.ComponentModel.DataAnnotations.Schema;
using MosquitoLab.Domain.Common.Entities;

namespace MosquitoLab.Domain.Samplings.Entities
{
    [Table("FieldSampling")]
    public class FieldSampling : CommonEntityWithKey
    {
        public int? AreaTypeId { get; set; }
        public int? StageMethodId { get; set; }
        public DateTime DateTime { get; set; }
        public string SpecificLocalityOriginalLanguage { get; set; }
        public string SpecificLocalityInEnglish { get; set; }
        public string SurroundingDescription { get; set; }
        public string Note { get; set; }
        public string TempLabCode { get; set; }
    }
}
