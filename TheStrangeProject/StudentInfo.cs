using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStrangeProject
{
    public class StudentInfo
    {
        public StudentInfo(int id) => Id = id;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"{Id} {Name} {Surname} {Age} {Group} {Description}";
    }
}
