using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IButantan.Wingbank.PackageGenerator
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
