using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_HOMEWORK
{
    [System.Xml.Serialization.XmlRoot("Baggage")]
    public class Baggage
    {
        [System.Xml.Serialization.XmlAttribute("Id")]
        public long Id { get; set; }
        [System.Xml.Serialization.XmlAttribute("OwnerId")]
        public long OwnerId { get; set; }
        [System.Xml.Serialization.XmlElement("Weight")]
        public double Weight { get; set; }
        [System.Xml.Serialization.XmlElement("Color")]
        public string Color { get; set; }
        [System.Xml.Serialization.XmlElement("Insides")]
        public string[] Inside { get; set; }
    }
}
