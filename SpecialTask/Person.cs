using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialTask
{
    public abstract class Person
    {
        private long _ID;
        private string _name;
        private byte _age;
        private Sex _sex;
        public long ID => _ID;
        public string Name => _name;
        public byte Age => _age;
        public Sex Sex => _sex;

        public Person(long ID, string name, byte age, Sex sex)
        {
            _ID = ID;
            _name = name;
            _age = age;
            _sex = sex;
        }

        public override string ToString()
        {
            return $"[ID:{ID}] Имя: {Name}|Пол: {Sex}|Возраст: {Age}";
        }
    }

    public enum Sex
    {
        Man = 0,
        Woman = 1,
        TransGender = 2,
        Alternative = 3 //clowns
    }
}
