using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_HOMEWORK
{
    [System.Xml.Serialization.XmlRoot("BaggageVisitor")]
    public class Visitor : Person
    {
        [System.Xml.Serialization.XmlElement("Cash")]
        public int Cash { get; set; }
        [System.Xml.Serialization.XmlElement("Baggage")]
        public Baggage Baggage { get; set; }
        [System.Xml.Serialization.XmlElement("Aim")]
        public Aim Aim { get; set; }
        [System.Xml.Serialization.XmlElement("Days")]
        public int Days { get; set; }
    }

    public enum Aim
    {
        Give = 0,
        Take = 1
    }
}
