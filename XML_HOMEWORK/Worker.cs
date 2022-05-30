using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_HOMEWORK
{
    [System.Xml.Serialization.XmlRoot("BaggageWorker")]
    public class Worker : Person
    {
        [System.Xml.Serialization.XmlElement("Profession")]
        public Profession Profession { get; set; }
    }

    public enum Profession
    {
        Security = 0,
        Cashier = 1
    }
}
