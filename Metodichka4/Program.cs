using System;

namespace Methodichka4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0;
            Console.WriteLine("Введите первое число: ");
            try
            {
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите второе число: ");
                num2 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"Введённые числа: {num1};{num2}");
            Console.WriteLine($"Задание 5.1:Большее из них: {BiggerNumber(num1, num2)}");
            SwapIt(ref num1, ref num2);
            Console.WriteLine($"Задание 5.2:Поменяны местами: {num1};{num2}");
            int temp = num1;
            Console.WriteLine($"Задание 5.3:Результат факториала первого из них({num1}) и успешна ли была опеарция: {Factorial(ref num1)};{num1}");
            Console.WriteLine($"Задание 5.4:Факториал второго: {FactorialRecursive(num2)} (Если 0 - значит произошло переполнение)");
            Console.WriteLine($"Домашнее Задание 5.1:НОД({temp};{num2}) = {EuclidNOD(temp, num2)}");
            Console.WriteLine($"Домашнее Задание 5.2:Число Фиббоначи #{temp}: {Fibo(temp)}");
            Console.WriteLine($"Домашнее Задание 5.2:Число Фиббоначи #{num2}: {Fibo(num2)}");
            Console.ReadKey();
        }

        private static int BiggerNumber(int option1, int option2) => Math.Max(option1, option2);

        private static void SwapIt(ref int option1, ref int option2)
        {
            int temp = option1;
            option1 = option2;
            option2 = temp;
        }

        private static bool Factorial(ref int num)
        {
            int limit = num;
            try
            {
                for (int i = 1; i <= limit; i++)
                {
                    checked
                    {
                        num *= i;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static long FactorialRecursive(long x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                try
                {
                    checked
                    {
                        return x * FactorialRecursive(x - 1);
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }

        private static int EuclidNOD(int input1, int input2)
        {
            while (input2 != input1)
            {
                if (input2 > input1)
                {
                    input2 -= input1;
                }
                else
                {
                    input1 -= input2;
                }
            }
            return input1;
        }

        private static int EuclidNOD(int input1, int input2, int input3)
        {
            return EuclidNOD(EuclidNOD(input1, input2), input3);
        }

        static long Fibo(long n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibo(n - 1) + Fibo(n - 2);
            }
        }
    }
}
