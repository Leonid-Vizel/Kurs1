using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork6
{
    class Program
    {
        static void Main()
        {
            Num1();
            Num2();
            Num3();
            Home1();
            Console.ReadKey();
        }

        private static void Num1()
        {
            Console.WriteLine("Задание #1");
            Console.Write("Введите номер счёта: ");
            if (!long.TryParse(Console.ReadLine(), out long inputID))
            {
                Console.WriteLine("Неверный формат, попробуйте снова!");
                Main();
                return;
            }
            Console.Write("Введите баланс счёта: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal inputBalance))
            {
                Console.WriteLine("Неверный формат, попробуйте снова!");
                Main();
                return;
            }
            Console.Write("Введите тип счёта(сберегательный/текущий): ");
            accountType inputType;
            switch (Console.ReadLine().ToLower())
            {
                case "сберегательный":
                    inputType = accountType.Savings;
                    break;
                case "текущий":
                    inputType = accountType.Current;
                    break;
                default:
                    Console.WriteLine("Неверный формат, попробуйте снова!");
                    Main();
                    return;
            }
            BankAccount1 ba = new BankAccount1(inputID, inputBalance, inputType);
            Console.WriteLine($"\n{ba}");
            Console.WriteLine("\nНажмите любую кнопку для перехода к следующему заданию");
            Console.ReadKey();
        }

        private static void Num2()
        {
            Console.WriteLine("Задание #2");
            Console.Write("Введите баланс счёта: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal inputBalance))
            {
                Console.WriteLine("Неверный формат, попробуйте снова!");
                Main();
                return;
            }
            Console.Write("Введите тип счёта(сберегательный/текущий): ");
            accountType inputType;
            switch (Console.ReadLine().ToLower())
            {
                case "сберегательный":
                    inputType = accountType.Savings;
                    break;
                case "текущий":
                    inputType = accountType.Current;
                    break;
                default:
                    Console.WriteLine("Неверный формат, попробуйте снова!");
                    Main();
                    return;
            }
            BankAccount2 ba = new BankAccount2(inputBalance, inputType);
            Console.WriteLine($"\n{ba}");
            Console.WriteLine("\nНажмите любую кнопку для перехода к следующему заданию");
            Console.ReadKey();
        }

        private static void Num3()
        {
            Console.WriteLine("Задание #3");
            Console.Write("Введите баланс счёта: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal inputBalance))
            {
                Console.WriteLine("Неверный формат, попробуйте снова!");
                Main();
                return;
            }
            Console.Write("Введите тип счёта(сберегательный/текущий): ");
            accountType inputType;
            switch (Console.ReadLine().ToLower())
            {
                case "сберегательный":
                    inputType = accountType.Savings;
                    break;
                case "текущий":
                    inputType = accountType.Current;
                    break;
                default:
                    Console.WriteLine("Неверный формат, попробуйте снова!");
                    Main();
                    return;
            }
            BankAccount3 ba = new BankAccount3(inputBalance, inputType);
            Console.WriteLine($"\n{ba}");
            Console.Write($"\nХотите добавить деньги на счёт(Y/N): ");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.Write("Сколько вы хотите добавить на счёт: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal addValue))
                {
                    Console.WriteLine("Неверный формат!");
                }
                else
                {
                    ba.Add(addValue);
                    Console.WriteLine($"\n{ba}");
                }
            }
            Console.Write($"\nХотите снять деньги со счёта(Y/N): ");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.Write("Сколько вы хотите снять со счёта: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal removeValue))
                {
                    Console.WriteLine("Неверный формат!");
                }
                else
                {
                    if (ba.Withdraw(removeValue) != removeValue)
                    {
                        Console.WriteLine("Со счёта не удалось снять нудную сумму.\nПричина: Недостаточно денег на балансе");
                    }
                    else
                    {
                        Console.WriteLine($"\n{ba}");
                    }
                }
            }
            Console.WriteLine("\nНажмите любую кнопку для перехода к следующему заданию");
            Console.ReadKey();
        }

        private static void Home1()
        {
            Console.WriteLine("Домащнее задание");
            Console.Write("Введите высоту здания:");
            if (!double.TryParse(Console.ReadLine(), out double inputHeight))
            {
                Console.WriteLine("Неверный формат!");
            }
            Console.Write("Введите кол-во подъездов:");
            if (!int.TryParse(Console.ReadLine(), out int inputEnters))
            {
                Console.WriteLine("Неверный формат!");
            }
            Console.Write("Введите кол-во этажей:");
            if (!int.TryParse(Console.ReadLine(), out int inputFloors))
            {
                Console.WriteLine("Неверный формат!");
            }
            Console.Write("Введите кол-во квартир:");
            if (!int.TryParse(Console.ReadLine(), out int inputFlats))
            {
                Console.WriteLine("Неверный формат!");
            }
            Building build = new Building(inputFlats, inputFloors, inputHeight, inputEnters);
            Console.WriteLine(build);
        }
    }
}
