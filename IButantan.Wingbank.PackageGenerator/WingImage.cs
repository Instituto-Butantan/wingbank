using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IButantan.Wingbank.PackageGenerator
{
    [Serializable]
    public class WingImage
    {
        [XmlIgnore]
        public string WingImageId { get; set; }

        [XmlElement("AccessionCode")]
        public string AccessionCode { get; set; }

        [XmlElement("Side")]
        public string Side { get; set; }

        [XmlElement("FileName")]
        public string FileName { get; set; }

        [XmlElement("ImageDimensions")]
        public string ImageDimensions { get; set; }

        [XmlElement("ImageDPI")]
        public string ImageDPI { get; set; }

        [XmlElement("ImageZoom")]
        public string ImageZoom { get; set; }

        [XmlElement("AcquirementEquipment")]
        public XmlCDataSection AcquirementEquipment { get; set; }

        [XmlElement("Individual")]
        public Individual Individual { get; set; }

        [XmlElement("Donation")]
        public Donation Donation { get; set; }

        [XmlElement("FieldSampling")]
        public FieldSampling FieldSampling { get; set; }

        [XmlElement("Colony")]
        public Colony Colony { get; set; }

        [XmlArray("PublicationsList")]
        [XmlArrayItem("Publication")]
        public List<Publication> PublicationList { get; set; }
    }
}
