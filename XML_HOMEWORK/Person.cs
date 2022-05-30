using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_HOMEWORK
{
    public abstract class Person
    {
        [System.Xml.Serialization.XmlAttribute("id")]
        public long Id { get; set; }
        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlElement("Age")]
        public byte Age { get; set; }
        [System.Xml.Serialization.XmlElement("Sex")]
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Man = 0,
        Woman = 1,
        TransGender = 2,
        Alternative = 3 //clowns
    }
}
