using System;

namespace ClassWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Num1();
            Num2();
            Num3();
            Num4();
            Num5();
            Num6();
            Num7();
            Num8();
            Num9();
            Num10();
            Console.ReadKey();
        }

        private static void Num1()
        {
            try
            {
                Console.Write("Введите трёхзначное число: ");
                short input = short.Parse(Console.ReadLine());
                if (input < 100 || input > 999) throw new Exception("Ваше число не является трёхзначным!");
                if (input / 100 == input % 100) Console.WriteLine($"{input} - является палиндромом");
                else Console.WriteLine($"{input} - является палиндромом");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
        }

        private static void Num2()
        {
            try
            {
                Console.Write("Введите длину форточки: ");
                short dlina = short.Parse(Console.ReadLine());
                Console.Write("Введите ширину форточки: ");
                short shirina = short.Parse(Console.ReadLine());
                Console.Write("Введите диаметр головы мальчика: ");
                short golova = short.Parse(Console.ReadLine());
                golova += 2; //Добавим рассчёт зазоров
                if (dlina <= golova) Console.WriteLine("Голову можно будет высунуть, блягодаря длине форточки");
                else if (shirina <= golova) Console.WriteLine("Голову можно будет высунуть, блягодаря ширине форточки");
                else Console.WriteLine("Не знаю как он туда пролез, но обратно пацан не вылезет, вызывайте МЧС!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
        }

        private static void Num3()
        {
            try
            {
                string[] calendar = new string[7] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
                Console.Write("Введите номер дня недели: ");
                Console.WriteLine($"Текущий день недели: {calendar[byte.Parse(Console.ReadLine()) - 1]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
        }
        private static void Num4()
        {
            try
            {
                string[] cards = new string[9] { "Шестёрка", "Семёрка", "Восьмёрка", "Девятка", "Десятка", "Валет", "Дама", "Король", "Туз" };
                Console.Write("Введите номер карты: ");
                Console.WriteLine($"Номинал карты: {cards[byte.Parse(Console.ReadLine()) - 6]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Попробуйте ещё раз, все ошибаются)))");
                Num4();
            }
        }

        private static void Num5()
        {
            const short radius = 6370;
            for (int h = 1; h <= 10; h++)
            {
                Console.WriteLine($"При высоте {h} км, расстояние до линии горизонта будет {Math.Sqrt(h * (2 * radius + h))}");
            }
        }

        private static void Num6()
        {
            try
            {
                Console.Write("Введите число: ");
                byte input = byte.Parse(Console.ReadLine());
                for (int i = 0; i <= 10; i++)
                {
                    Console.WriteLine($"{input}*{i}={input * i}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private static void Num7()
        {
            try
            {
                long sum = 0;
                int count = 0;
                Console.WriteLine("Вводите сколько угодно чисел последовательности. Если захотите завершить ввод - введите любое отрицательное число.");
                int input = int.Parse(Console.ReadLine());
                while (input >= 0)
                {
                    sum += input;
                    count++;
                    input = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Среднее арифметическое данного набора чисел: {(double)sum / count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Попробуйте ещё раз, все ошибаются)))");
                Num7();
            }
        }
        private static void Num8()
        {
            long last = long.MinValue;
            Console.WriteLine("Введите 10 чисел: ");
            for (int i = 0; i < 10; i++)
            {
                long input = long.Parse(Console.ReadLine());
                if (input < last)
                {
                    Console.WriteLine("Найден элемент, не расположенный в порядке возрастания");
                }
                else if (i == 9)
                {
                    Console.WriteLine("Последовательноть расположена по возрастанию");
                }
                last = input;
            }
        }

        private static void Num9()
        {
            long input = long.Parse(Console.ReadLine());
            int counter = 0;
            long sum = 0;
            Console.WriteLine("Введите последовательность чисел: ");
            while (input != 0)
            {
                counter++;
                if (counter % 3 == 0) sum += input;
                input = long.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Сумма элементов, индексы которых кратны 3, равна {sum}");
        }

        private static void Num10()
        {
            long sum = 0;

        Entry:
            long input = long.Parse(Console.ReadLine());
            sum += input;
            if (input != 0) goto Entry;
            else Console.WriteLine($"Сумма последовательнсти: {sum}");

        }
    }
}
