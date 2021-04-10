using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IButantan.Wingbank.PackageGenerator
{
    [Serializable]
    public class WingImagesList
    {
        [XmlElement("WingImage")]
        public List<WingImage> List { get; set; }
    }
}
