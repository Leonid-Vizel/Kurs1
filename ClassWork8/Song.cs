namespace ClassWork8
{
    class Song
    {
        private string name; //название песни
        private string author; //автор песни
        private Song prev; //связь с предыдущей песней в списке
        public static Song Parse(string input)
        {
            string[] splitArray = input.Split(' ');
            if (splitArray.Length == 2)
            {
                return new Song(splitArray[0].Replace("_", " "), splitArray[1].Replace("_", " "));
            }
            else
            {
                return null;
            }
        }
        public static Song Default => new Song("DefaultName", "DefaultAuthor");
        public Song(string name, string author, Song prev = null)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }
        public Song()
        {
            name = "DefaultName";
            author = "DefaultAuthor";
            prev = null;
        }
        public string GetName() => name;
        public string GetAuthor() => author;
        public Song GetPrev() => prev;
        public void SetName(string value) => name = value;
        public void SetAuthor(string value) => author = value;
        public void SetPrev(Song value) => prev = value;
        public string Title => $"{name} {author}";
        public override bool Equals(object d)
        {
            if (d is Song)
            {
                Song compare = (Song)d;
                return (compare.name.Equals(name)) && (compare.author.Equals(author));
            }
            else
            {
                return false;
            }
        }
        public override string ToString() => $"Инормация о песне: {Title}\nНаименование: {name}\nАвтор: {author}";
    }
}
