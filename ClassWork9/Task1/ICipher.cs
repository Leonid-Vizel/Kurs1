namespace ClassWork9
{
    public interface ICipher
    {
        string Alphabet { get; }
        string UpperAlphabet { get; }
        string encode(string input);
        string decode(string input);
    }
}
