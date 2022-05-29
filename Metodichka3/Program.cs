using System;

namespace Metodichka3
{
    class Program
    {
        static void Main(string[] args)
        {
            Num1();
            Num2();
            Num3();
            Console.ReadKey();
        }

        private static void Num1()
        {
            short inputDays = 0;
            byte count = 0;
            byte[] daysInMonths = new byte[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] monthNames = new string[12] { "января", "февраля", "марта", "апрель", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            Console.Write("Задание #1: Введите количество дней:");
            try
            {
                inputDays = short.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибочка: Неверный формат ввода");
                return;
            }
            inputDays %= 365;
            while (inputDays > daysInMonths[count])
            {
                inputDays -= daysInMonths[count++];
            }
            if (inputDays == 0)
            {
                if (count == 0)
                {
                    count = 12;
                }
                inputDays = daysInMonths[--count];
            }
            Console.WriteLine($"Результат: {inputDays} {monthNames[count]}");
        }

        private static void Num2()
        {
            short inputDays = 0;
            byte count = 0;
            byte[] daysInMonths = new byte[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] monthNames = new string[12] { "января", "февраля", "марта", "апрель", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            Console.Write("Задание #2: Введите количество дней:");
            try
            {
                inputDays = short.Parse(Console.ReadLine());
                if (inputDays < 0 || inputDays > 365) throw new Exception("Введено неверное количество дней!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}");
                return;
            }
            inputDays %= 365;
            while (inputDays > daysInMonths[count])
            {
                inputDays -= daysInMonths[count++];
            }
            if (inputDays == 0)
            {
                if (count == 0)
                {
                    count = 12;
                }
                inputDays = daysInMonths[--count];
            }
            Console.WriteLine($"Результат: {inputDays} {monthNames[count]}");
        }

        private static void Num3()
        {
            short inputDays = 0, inputYear = 0;
            byte monthCount = 0;
            bool visokos = false;
            byte[] daysInMonths = new byte[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] monthNames = new string[12] { "января", "февраля", "марта", "апрель", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            Console.Write("Задание #3: Введите год:");
            try
            {
                inputYear = short.Parse(Console.ReadLine());
                if (inputYear <= 0) throw new Exception("Значение года не может быть отрицательным или равным нулю!");
                visokos = (inputYear % 4 == 0 && inputYear % 100 != 0) || (inputYear % 4 == 0 && inputYear % 100 == 0);
                Console.Write("Введите день:");
                inputDays = short.Parse(Console.ReadLine());
                if (inputDays < 0 || (!visokos && inputDays > 365) || (visokos && inputDays > 366)) throw new Exception("Введено неверное количество дней!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}");
                return;
            }
            if (visokos)
            {
                daysInMonths[1] = 29;
                inputDays %= 366;
            }
            else
            {
                inputDays %= 365;
            }
            while (inputDays > daysInMonths[monthCount])
            {
                inputDays -= daysInMonths[monthCount++];
            }
            if (inputDays == 0)
            {
                if (monthCount == 0)
                {
                    monthCount = 12;
                }
                inputDays = daysInMonths[--monthCount];
            }
            Console.WriteLine($"Результат: {inputDays} {monthNames[monthCount]}");
        }
    }
}
