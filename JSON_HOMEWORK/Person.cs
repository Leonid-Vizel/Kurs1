using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_HOMEWORK
{
    public abstract class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
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
