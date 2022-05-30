using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_HOMEWORK
{
    public class Visitor : Person
    {
        public int Cash { get; set; }
        public Baggage Baggage { get; set; }
        public Aim Aim { get; set; }
        public int Days { get; set; }
    }

    public enum Aim
    {
        Give = 0,
        Take = 1
    }
}
