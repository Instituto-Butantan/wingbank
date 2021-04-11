using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MosquitoLab.Infra.PackageGenerator
{
    [Serializable]
    public class WingImagesList
    {
        [XmlElement("WingImage")]
        public List<WingImage> List { get; set; }
    }
}
