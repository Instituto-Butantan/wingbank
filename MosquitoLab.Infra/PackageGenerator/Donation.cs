using System;
using System.Xml.Serialization;

namespace MosquitoLab.Infra.PackageGenerator
{
    [Serializable]
    public class Donation
    {
        [XmlElement("OriginalCode")]
        public string OriginalCode { get; set; }

        [XmlElement("DateTime")]
        public DateTime DateTime { get; set; }

        [XmlElement("Institution")]
        public Institution Institution { get; set; }
    }
}