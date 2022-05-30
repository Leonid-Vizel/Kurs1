using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_HOMEWORK
{
    public class Worker : Person
    {
        public Profession Profession { get; set; }
    }

    public enum Profession
    {
        Security = 0,
        Cashier = 1
    }
}
