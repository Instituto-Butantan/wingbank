using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace MosquitoLab.Infra.PackageGenerator
{
    [Serializable]
    public class Publication
    {
        [XmlElement("PublicationId")]
        public string PublicationId { get; set; }

        [XmlElement("Title")]
        public XmlCDataSection Title { get; set; }

        [XmlElement("Year")]
        public string Year { get; set; }

        [XmlElement("Publisher")]
        public string Publisher { get; set; }

        [XmlElement("Number")]
        public string Number { get; set; }

        [XmlElement("Volume")]
        public string Volume { get; set; }

        [XmlElement("Url")]
        public XmlCDataSection Url { get; set; }

        [XmlElement("Doi")]
        public XmlCDataSection Doi { get; set; }

        [XmlElement("Jornal")]
        public XmlCDataSection Jornal { get; set; }

        [XmlArray("AuthorsList")]
        [XmlArrayItem("Author")]
        public List<Author> AuthorsList { get; set; }
    }
}