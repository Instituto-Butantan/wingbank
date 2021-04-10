using System;

namespace MosquitoLab.Domain.Individuals.Filters
{
    public class WingFilter
    {
        public string Text { get; set; }
        public string SpecificLocality { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime? Date { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public char? Gender { get; set; }
        public char? WingSide { get; set; }
        public int? Family { get; set; }
        public int? Subfamily { get; set; }
        public int? Genus { get; set; }
        public int? Specie { get; set; }
        public string InstitutionName { get; set; }
        public string MosquitoLabCode { get; set; }
        public string Lecz { get; set; }
        public int? Tribe { get; set; }
    }
}
