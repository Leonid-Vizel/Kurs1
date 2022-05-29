using System.Linq;

namespace ClassWork8
{
    public class BCipher : ICipher
    {
        public virtual string Alphabet { get; }
        public virtual string UpperAlphabet { get; }
        public BCipher(string lowerAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя")
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
                upper = UpperAlphabet.Contains(c);
                index = upper ? UpperAlphabet.IndexOf(c) : Alphabet.IndexOf(c);

                if (index > 0)
                {
                    index = Alphabet.Length - index - 1;
                    result += upper ? UpperAlphabet[index] : Alphabet[index];
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        public string decode(string input) => encode(input);
    }
}
