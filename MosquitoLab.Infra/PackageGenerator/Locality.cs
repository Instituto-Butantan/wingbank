using System;
using System.Xml.Serialization;

namespace MosquitoLab.Infra.PackageGenerator
{
    [Serializable]
    public class Locality
    {
        [XmlElement("CountryCode")]
        public string CountryCode { get; set; }

        [XmlElement("Country")]
        public string Country { get; set; }

        [XmlElement("StateOrProvinceCode")]
        public string StateOrProvinceCode { get; set; }

        [XmlElement("StateOrProvince")]
        public string StateOrProvince { get; set; }

        [XmlElement("City")]
        public string City { get; set; }

        [XmlElement("Neighborhood")]
        public string Neighborhood { get; set; }

        [XmlElement("Address")]
        public string Address { get; set; }

        [XmlElement("Zipcode")]
        public string Zipcode { get; set; }

        [XmlElement("Altitude")]
        public string Altitude { get; set; }
    }
}