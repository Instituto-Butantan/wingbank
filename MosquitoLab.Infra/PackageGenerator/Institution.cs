using System;
using System.Xml.Serialization;

namespace MosquitoLab.Infra.PackageGenerator
{
    [Serializable]
    public class Institution
    {
        [XmlElement("InstitutionId")]
        public string InstitutionId { get; set; }

        [XmlElement("Abbreviation")]
        public string Abbreviation { get; set; }

        [XmlElement("NameInEnglish")]
        public string NameInEnglish { get; set; }

        [XmlElement("NameOriginalLanguage")]
        public string NameOriginalLanguage { get; set; }
    }
}