namespace ClassWork9
{
    public class ACipher : ICipher
    {
        public virtual string Alphabet { get; }
        public virtual string UpperAlphabet { get; }
        public ACipher(string lowerAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя")
        {
            Alphabet = lowerAlphabet.ToLower();
            UpperAlphabet = lowerAlphabet.ToUpper();
        }
        public string encode(string input)
        {
            bool upper;
            int index;
            string result = string.Empty;
            foreach (char c in input)
            {
                upper = UpperAlphabet.Contains(c.ToString());
                index = upper ? UpperAlphabet.IndexOf(c) : Alphabet.IndexOf(c);

                if (index > 0)
                {
                    index = (index + 1) % UpperAlphabet.Length;
                    result += upper ? UpperAlphabet[index] : Alphabet[index];
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
        public string decode(string input)
        {
            bool upper;
            int index;
            string result = string.Empty;
            foreach (char c in input)
            {
                upper = UpperAlphabet.Contains(c.ToString());
                index = upper ? UpperAlphabet.IndexOf(c) : Alphabet.IndexOf(c);

                if (index > 0)
                {
                    index = (Alphabet.Length + index - 1) % Alphabet.Length;
                    result += upper ? UpperAlphabet[index] : Alphabet[index];
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
    }
}
