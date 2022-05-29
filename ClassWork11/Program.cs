#define DEBUG_ACCOUNT
using System;

namespace ClassWork11
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTaskNumber(14.1);
            new BankAccount(accountType.Current).DumpToScreen();
            PrintTaskNumber(14.2);
            foreach (Attribute attr in typeof(Rational).GetCustomAttributes(false))
            {
                if (attr is DeveloperInfoAttribute)
                {
                    DeveloperInfoAttribute devAttr = attr as DeveloperInfoAttribute;
                    Console.WriteLine($"{devAttr.DevName} {devAttr.DevTime:dd.MM.yyyy HH:mm:ss}");
                }
            }
            PrintTaskNumber(14.1);
            foreach (Attribute attr in typeof(BankAccount).GetCustomAttributes(false))
            {
                if (attr is DevelopementInfoAttribute)
                {
                    DevelopementInfoAttribute devAttr = attr as DevelopementInfoAttribute;
                    Console.WriteLine($"Имя:{devAttr.DevName} Организация:{devAttr.DevOrg}");
                }
            }
            Console.ReadLine();
        }

        private static void PrintTaskNumber(double num)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Задание {num}:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
