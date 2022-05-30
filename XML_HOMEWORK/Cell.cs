using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_HOMEWORK
{
    [System.Xml.Serialization.XmlRoot("BaggageCell")]
    public class Cell
    {
        [System.Xml.Serialization.XmlAttribute("id")]
        public long Id { get; set; }
        [System.Xml.Serialization.XmlElement("WeightLimit")]
        public double WeightLimit { get; set; }
        [System.Xml.Serialization.XmlElement("BaggageInside")]
        public Baggage Baggage { get; set; }
    }
}
