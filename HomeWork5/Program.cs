using System;
using System.IO;
using System.Linq;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            Num1();
            Num2();
            Console.ReadLine();
        }

        private static void Num1()
        {
            Console.WriteLine("Задание #1");
            string answer = "";
            foreach (string s in File.ReadAllText("password.txt").Split(' '))
            {
                answer += StringBinaryToChar(s);
            }
            Console.WriteLine("Введите ваши варианты пароля(для завершения нажмите enter):");
            bool found = false;
            string input = "";
            do
            {
                input = Console.ReadLine();
                found |= (input.Equals(answer));
            }
            while (input.Length > 0);
            if (found)
            {
                Console.WriteLine($"Пароль отгадан: {answer}");
            }
            else
            {
                Console.WriteLine($"Пароль не отгадан");
            }

            //Вариант с листом
            //List<string> userVariants = new List<string>();
            //Console.WriteLine("Введите ваши варианты пароля(для завершения нажмите enter):");
            //do
            //{
            //    userVariants.Add(Console.ReadLine());
            //}
            //while (userVariants.Last().Length > 0);
            //userVariants.RemoveAt(userVariants.Count - 1);
            //if (userVariants.Contains(answer))
            //{
            //    Console.WriteLine($"Пароль отгадан: {answer}");
            //}
            //else
            //{
            //    Console.WriteLine($"Пароль не отгадан");
            //}
        }

        private static void Num2()
        {
            Console.WriteLine("Задание #2");
            char[] replacements = new char[]
            {
                'О','У','Э','Ы','Я','Ё','Е','Ю','И',
                'E','I','O','U','Y'
            };
            Console.Write("Введите речь Гордона Рамзи: ");
            string speech = Console.ReadLine().ToUpper().Replace("A", "@").Replace("А", "@").Replace(" ", "!!! ");
            foreach (string rep in replacements.Select(x => x.ToString()))
            {
                speech = speech.Replace(rep, "*");
            }
            if (!speech.EndsWith("!!!"))
            {
                speech += "!!!";
            }
            Console.WriteLine($"Вот безопасный для прочтения текст: {speech}");
        }

        private static char StringBinaryToChar(string binary)
        {
            short number = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i].Equals('1'))
                {
                    number += (short)Math.Pow(2, binary.Length - 1 - i);
                }
            }
            return (char)number;
        }
    }
}
