using System;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            lab21();
            lab22();
            labDZ1();
            labDZ2();
            Console.ReadKey();
        }

        public static void lab21()
        {
            Console.Write($"Введите Ваше имя: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Приветствую Тебя, о великий(-ая) {name}!");
        }
        public static void lab22()
        {
            try
            {
                Console.Write("Введите делимое: ");
                decimal num1 = Decimal.Parse(Console.ReadLine());
                Console.Write("Введите делитель: ");
                decimal num2 = Decimal.Parse(Console.ReadLine());
                try
                {
                    Console.WriteLine($"Результат операции: {num1 / num2}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("На ноль делить нельзя!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошиба чтения, числа введены неправильно");
            }
        }

        public static void labDZ1()
        {
            Console.Write("Введите букву: ");
            char c = Console.ReadKey().KeyChar;
            switch (c.ToString().ToLower())
            {
                case "z":
                    Console.WriteLine($"\nСледующая буква: a");
                    break;
                case "я":
                    Console.WriteLine($"\nСледующая буква: а");
                    break;
                default:
                    Console.WriteLine($"\nСледующая буква: {(char)((int)c + 1)}");
                    break;
            }
        }

        public static void labDZ2()
        {
            try
            {
                Console.Write("Введите старший коэффициент: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Второй коэффициент: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Свободный член: ");
                double c = double.Parse(Console.ReadLine());
                try
                {
                    double descr = b * b - 4 * a * c; //находим дискриминант
                    if (descr <= 0) throw new Exception("Дискриминант меньше нуля");
                    double x1 = (-b - Math.Sqrt(descr)) / (2 * a); //Первый корень
                    double x2 = (-b + Math.Sqrt(descr)) / (2 * a); //Второй корень
                    Console.WriteLine($"Ответы: {Math.Round(x1, 2)}; {Math.Round(x2, 2)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка расчёта: {ex.Message}");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка чтения, числа введены неправильно");
            }
        }
    }
}
