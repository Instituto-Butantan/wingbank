using System;
using System.Text;
using MosquitoLab.Domain.Individuals.Enums;

namespace MosquitoLab.Domain.Individuals.Dtos
{
    public class WingResultDto
    {
        public int Id { get; set; }
        public WingSide? WingSide { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? SamplingDate { get; set; }

        public string Title => new StringBuilder()
            .Append(string.IsNullOrEmpty(FamilyName) ? "" : FamilyName)
            .Append(string.IsNullOrEmpty(SubfamilyName) ? "" : " " + SubfamilyName)
            .Append(string.IsNullOrEmpty(Genera) ? "" : " " + Genera)
            .Append(string.IsNullOrEmpty(SubgenericName) ? "" : " " + SubgenericName)
            .Append(string.IsNullOrEmpty(Specie) ? "" : " " + Specie)
            .Append(string.IsNullOrEmpty(SubspeciesName) ? "" : " " + SubspeciesName)
            .Append(string.IsNullOrEmpty(TribeName) ? "" : " " + TribeName)
            .ToString();

        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }

        public int? FamilyId { get; set; }
        public string FamilyName { get; set; }
        public string SubfamilyName { get; set; }
        public int? SubfamilyId { get; set; }
        public string Genera { get; set; }
        public int? GeneraId { get; set; }
        public string SubgenericName { get; set; }
        public int SubgenusId { get; set; }
        public string Specie { get; set; }
        public int? SpecieId { get; set; }
        public string SubspeciesName { get; set; }
        public string TribeName { get; set; }
        public int TribeId { get; set; }

    }
}
