using System.Collections.Generic;
using System.IO;

namespace ClassWork10
{
    class Student
    {
        public readonly string name;
        public readonly string surname;
        public readonly string group;
        public byte tickets;
        private bool[] wins;
        public string SaveString => $"{name} {surname} {group} {tickets} {wins[0]} {wins[1]} {wins[2]}";
        public string FullName => $"{name} {surname}";
        public byte luckAmount
        {
            get
            {
                byte result = 4;
                foreach (bool win in wins)
                {
                    if (win)
                    {
                        result--;
                    }
                }
                return result;
            }
        }
        public Student(string name, string surname, string group, byte tickets, bool won1, bool won2, bool won3)
        {
            this.name = name;
            this.surname = surname;
            this.group = group;
            this.tickets = tickets;
            wins = new bool[3] { won1, won2, won3 };
        }

        public static List<Student> ReadAll(string path)
        {
            List<Student> students = new List<Student>();
            string[] readLines = File.ReadAllLines(path);
            foreach(string line in readLines)
            {
                string[] parseArray = line.Split(' ');
                if (parseArray.Length == 7)
                {
                    if (!byte.TryParse(parseArray[3],out byte tickets))
                    {
                        continue;
                    }
                    Student student = new Student(parseArray[0], parseArray[1], parseArray[2], tickets, parseArray[4].Equals("True"), parseArray[5].Equals("True"), parseArray[6].Equals("True"));
                    students.Add(student);
                }
            }
            return students;
        }

        public void ShiftWins(bool last)
        {
            wins[2] = wins[1];
            wins[1] = wins[0];
            wins[0] = last;
        }
    }
}
