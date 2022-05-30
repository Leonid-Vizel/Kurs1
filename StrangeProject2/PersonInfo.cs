namespace AudioTest
{
    public class PersonInfo
    {
        public int Id { get; private set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PersonInfo(int id)
        {
            Id = id;
        }

        public override string ToString() => $"{Id} {Surname} {Name} {Description}\n";

        public static PersonInfo FromString(string input)
        {
            string[] parseStrings = input.Split(' ');
            if (parseStrings.Length >= 3)
            {
                PersonInfo info = new PersonInfo(int.Parse(parseStrings[0]))
                {
                    Surname = parseStrings[1],
                    Name = parseStrings[2],
                    Description = parseStrings[3],
                };
                for (int i = 4; i < parseStrings.Length; i++)
                {
                    info.Description += $" {parseStrings[i]}";
                }
                return info;
            }
            else
            {
                return null;
            }
        }
    }
}
