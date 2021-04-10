using System;
using System.Xml;
using System.Xml.Serialization;

namespace MosquitoLab.Infra.PackageGenerator
{
    [Serializable]
    public class TaxonomicClassification
    {
        [XmlElement("Method")]
        public string Method { get; set; }

        [XmlElement("Reference")]
        public XmlCDataSection Reference { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("Family")]
        public string Family { get; set; }

        [XmlElement("Subfamily")]
        public string Subfamily { get; set; }

        [XmlElement("Tribe")]
        public string Tribe { get; set; }

        [XmlElement("Genus")]
        public string Genus { get; set; }

        [XmlElement("Subgenus")]
        public string Subgenus { get; set; }

        [XmlElement("SpecificEpithet")]
        public string SpecificEpithet { get; set; }

        [XmlElement("SubspecificEpithet")]
        public string SubspecificEpithet { get; set; }
    }
}