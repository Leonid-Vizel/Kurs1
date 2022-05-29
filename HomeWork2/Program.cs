using System;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            Num11();
            Num12();
            Num13();
            Num14();
            Num15();
            Num16();
            Num17();
            Num18();
            Num19();
            Num110();
            Additional1();
            Additional2();
            //Waiting;
            Console.ReadLine();
        }

        private static void Num11()
        {
            try
            {
                Console.Write("Задание №1.1: Введите кол-во секунд: ");
                long seconds = long.Parse(Console.ReadLine());
                seconds %= 86400;
                Console.WriteLine($"1.1-a) Прошло {seconds / 3600} полных часов с начала суток");
                seconds &= 3600;
                Console.WriteLine($"1.1-б) Прошло {seconds / 60} полных минут с начала часа");
                seconds %= 60;
                Console.WriteLine($"1.1-в) Прошло {seconds} полных секунд с начала минуты");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
        }

        private static void Num12()
        {
            Console.WriteLine($"Задание №1.2: Ответ:{(543 / 130)}"); //Сократил выражение, так как в числителе и знаменателе присутствовало число 130
        }

        private static void Num13()
        {
            try
            {
                Console.Write("Задание №1.3: Введите кол-во месяцев: ");
                Console.WriteLine($"Ответ: {int.Parse(Console.ReadLine()) % 12 + 1}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
        }

        private static void Num14()
        {
            try
            {
                Console.Write("Задание №1.4: Введите двузначное число: ");
                byte input = byte.Parse(Console.ReadLine());
                if (input < 10 || input > 99) throw new Exception("Это число не является двузначным");
                Console.WriteLine($"Задание №1.4-а: {input / 10}");
                Console.WriteLine($"Задание №1.4-б: {input % 10}");
                Console.WriteLine($"Задание №1.4-в: {(input / 10) + (input % 10)}");
                Console.WriteLine($"Задание №1.4-г: {(input / 10) * (input % 10)}");
                //Можно было посчитаьь через While
                //int sum=0,multiply=1;
                //while(input>0)
                //{
                //sum+=input%10;
                //multiply*=input%10;
                //input /= 10;
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void Num15()
        {
            try
            {
                Console.Write("Задание №1.5: Введите трёхзначное число: ");
                short input = short.Parse(Console.ReadLine());
                if (input < 100 || input > 999) throw new Exception("Это число не является трёхзначным");
                Console.Write($"Ответ: {input % 100}{input / 100}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void Num16()
        {
            Console.WriteLine($"Задание №1.6: {(237 % 100) * 10 + 2}");
        }

        private static void Num17()
        {
            try
            {
                Console.Write("Задание №1.7: Введите двузначное число: ");
                byte input1 = byte.Parse(Console.ReadLine());
                Console.Write("Введите ещё одно двузначное число: ");
                byte input2 = byte.Parse(Console.ReadLine());
                int c1 = (input1 % 10) + (input2 % 10);
                int c2 = (input1 / 10) + (input2 / 10) + (c1 / 10);
                c1 %= 10;
                Console.Write($"Ответ: {c2}{c1}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void Num18()
        {
            int[] array = new int[150];
            int i = 0, j = 101, k = 0;
            while (i < 150)
            {
                array[i] = 1;
                array[i + 1] = j / 10 % 10;
                array[i + 2] = j % 10;
                j++;
                i += 3;
            }
            Console.WriteLine("При k кратном 3:");
            for (k = 3; k <= 150; k += 3) Console.Write($"{k} - {array[k - 1]} | ");
            Console.WriteLine();
            Console.WriteLine("При k = 1,4,7...:");
            for (k = 1; k <= 150; k += 3) Console.Write($"{k} - {array[k - 1]} | ");
            Console.WriteLine();
            Console.WriteLine("При k = 2,5,8...");
            for (k = 2; k <= 150; k += 3) Console.Write($"{k} - {array[k - 1]} | ");
            Console.WriteLine();
        }

        private static void Num19()
        {
            bool A = true, B = false, C = false;
            Console.WriteLine($"Задание №1.9-а: {A || B}");
            Console.WriteLine($"Задание №1.9-b: {A && B}");
            Console.WriteLine($"Задание №1.9-c: {B || C}");
        }

        private static void Num110()
        {
            bool x = false, y = false, z = false;
            Console.WriteLine("Задание №1.10-a:");
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //000
            x = false; y = false; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //001
            x = false; y = true; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //010
            x = false; y = true; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //011
            x = true; y = false; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //100
            x = true; y = false; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //101
            x = true; y = true; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //110
            x = true; y = true; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(x || y) && (!x || !z)}"); //111
            x = false; y = false; z = false;

            Console.WriteLine("Задание №1.10-б:");
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //000
            x = false; y = false; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //001
            x = false; y = true; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //010
            x = false; y = true; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //011
            x = true; y = false; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //100
            x = true; y = false; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //101
            x = true; y = true; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //110
            x = true; y = true; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={!(!x && y) || (x && !z)}"); //111
            x = false; y = false; z = false;

            Console.WriteLine("Задание №1.10-в:");
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //000
            x = false; y = false; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //001
            x = false; y = true; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //010
            x = false; y = true; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //011
            x = true; y = false; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //100
            x = true; y = false; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //101
            x = true; y = true; z = false;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //110
            x = true; y = true; z = true;
            Console.WriteLine($"X={x},X={y},X={z},F(X,Y,Z)={x || !y && !(x || !z)}"); //111
        }

        private static void Additional1()
        {
            try
            {
                Console.Write("Задание №1-ДОПОЛНИТЕЛЬНО: Введите количество лепестков: ");
                short input1 = short.Parse(Console.ReadLine());
                Console.Write("Введите количество лепестков другого цветка: ");
                short input2 = short.Parse(Console.ReadLine());
                Console.WriteLine($"Ответ: {input1 % 2 != input2 % 2}".Replace("True", "Влюблены<3").Replace("False", "Не влюблены"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void Additional2()
        {
            try
            {
                Console.Write("Задание №2-ДОПОЛНИТЕЛЬНО: Введите продолжительность поездки в часах: ");
                Console.WriteLine($"Натан выпьет {Math.Truncate(double.Parse(Console.ReadLine().Replace(".", ",")) / 2)} литров воды за эту поездку");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}