using System;
using System.Xml.Serialization;

namespace MosquitoLab.Infra.PackageGenerator
{
    [Serializable]
    public class Individual
    {
        [XmlElement("individualId")]
        public string individualId { get; set; }

        [XmlElement("Gender")]
        public string Gender { get; set; }

        [XmlElement("TaxonomicClassification")]
        public TaxonomicClassification TaxonomicClassification { get; set; }
    }
}
