using System;
using System.Xml;
using System.Xml.Serialization;

namespace IButantan.Wingbank.PackageGenerator
{
    [Serializable]
    public class FieldSampling
    {
        [XmlElement("FieldSamplingId")]
        public string FieldSamplingId { get; set; }

        [XmlElement("DateTime")]
        public DateTime DateTime { get; set; }

        [XmlElement("AreaType")]
        public string AreaType { get; set; }

        [XmlElement("SpecificLocalityInEnglish")]
        public XmlCDataSection SpecificLocalityInEnglish { get; set; }

        [XmlElement("SpecificLocalityOriginalLanguage")]
        public XmlCDataSection SpecificLocalityOriginalLanguage { get; set; }

        [XmlElement("SurroundingDescription")]
        public XmlCDataSection SurroundingDescription { get; set; }

        [XmlElement("Stage")]
        public string Stage { get; set; }

        [XmlElement("SamplingMethod")]
        public string SamplingMethod { get; set; }
        
        [XmlElement("Note")]
        public XmlCDataSection Note { get; set; }

        [XmlElement("Locality")]
        public Locality Locality { get; set; }
    }
}