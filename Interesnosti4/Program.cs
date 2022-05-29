using System;
using System.Collections.Generic;
using System.Linq;


namespace Interesnosti4
{
    class Program
    {
        private static string[] column1 = new string[]
        {
            "Это текст",
            "Это материал",
            "Это статья",
            "Это публикация",
            "Это данные",
            "Это информация",
            "Материал",
            "Текст",
            "Статья",
            "Публикация",
            "Данные",
            "Информация"
        };
        private static string[] column2 = new string[]
        {
            "сайта",
            "книги",
            "библиотеки",
            "каталога",
            "системы"
        };
        private static string[] column3 = new string[]
        {
            "Univer",
            "univer.ququ",
            "Универ"
        };
        private static string[][] columns = new string[][] { column1, column2, column3 };
        private static Random rnd = new Random(DateTime.Now.Millisecond);
        private static Dictionary<char, char> RuEnReplace = new Dictionary<char, char>();
        static void Main(string[] args)
        {
            RuEnReplace.Add('Т', 'T');
            RuEnReplace.Add('х', 'x');
            RuEnReplace.Add('С', 'C');
            RuEnReplace.Add('с', 'c');
            RuEnReplace.Add('е', 'e');
            RuEnReplace.Add('у', 'y');
            RuEnReplace.Add('а', 'a');
            RuEnReplace.Add('р', 'p');
            RuEnReplace.Add('о', 'o');
            Console.WriteLine($"Вот Ваша фраза: {randomZeroSpaceInsert(randomReplaceRuEn($"{randomWord(1)} {randomWord(2)}"))} {randomZeroSpaceInsert(randomWord(3))}.");
            Console.ReadKey();
        }

        private static string randomWord(byte n)
        {
            return columns[--n][rnd.Next(0, columns[n].Length)];
        }

        private static string randomZeroSpaceInsert(string str)
        {
            return str.Insert(rnd.Next(0, str.Length), " ");
        }    

        private static string randomReplaceRuEn(string str)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (RuEnReplace.Keys.Contains(str[i]))
                {
                    indexes.Add(i);
                }
            }
            if (indexes.Count > 0)
            {
                int randomResult = rnd.Next(0, indexes.Count);
                char replacement = RuEnReplace[str[indexes[randomResult]]];
                str = str.Remove(indexes[randomResult], 1);
                str = str.Insert(indexes[randomResult], replacement.ToString());
            }
            return str;
        }
    }
}
