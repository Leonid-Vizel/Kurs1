using System;

namespace HomeWork3
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
            Num21();
            Num22();
            Num23();
            Num31();
            Num32();
            Num33();
            Num34();
            Num35();
            Additional();
            Console.ReadKey();
        }

        private static void Num11()
        {
            try
            {
                Console.Write("Задание 1.1: Введите вещественное число:");
                double input = double.Parse(Console.ReadLine().Replace(".", ","));
                //Возведём в квадрат, а потом возьмём из этого корень, чтобы получить модуль без функций и условных операторов
                Console.WriteLine($"Результат: {Math.Sqrt(input * input)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}");
            }
        }

        private static void Num12()
        {
            try
            {
                Console.Write("Задание 1.2: Введите число #1:");
                double input1 = double.Parse(Console.ReadLine().Replace(".", ","));
                Console.Write("Введите число #2:");
                double input2 = double.Parse(Console.ReadLine().Replace(".", ","));
                if (Math.Abs(input2) > Math.Abs(input1))
                {
                    input1 /= 2;
                }
                Console.WriteLine($"Число #1: {input1}\nЧисло #2: {input2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}");
            }
        }

        private static void Num13()
        {
            Console.Write("Задание 1.3:Введите животное, которое встретила лягуха: ");
            string animalName = Console.ReadLine().ToLower();
            if (animalName == "аллигатор")
            {
                Console.WriteLine("mouthSize = small");
            }
            else
            {
                Console.WriteLine("mouthSize = wide");
            }
        }

        private static void Num14()
        {
            Console.Write("Задание 1.4: Кто на этот раз посетит наш бар? ");
            string visitorName = Console.ReadLine().ToLower();
            switch (visitorName)
            {
                case "jabroni":
                    Console.WriteLine("Patron Tequila");
                    break;
                case "school counselor":
                    Console.WriteLine("Anything with Alcohol");
                    break;
                case "programmer":
                    Console.WriteLine("Hipster Craft Beer");
                    break;
                case "bike gang member":
                    Console.WriteLine("Moonshine");
                    break;
                case "politician":
                    Console.WriteLine("Your tax dollars");
                    break;
                case "rapper":
                    Console.WriteLine("Cristal");
                    break;
                default:
                    Console.WriteLine("Beer");
                    break;
            }
        }

        private static void Num15()
        {
            Console.Write("Задание 1.5: Say something: ");
            Console.WriteLine($"Результат: {Console.ReadLine().ToLower().Contains("english")}");
        }

        private static void Num21()
        {
            Console.WriteLine("Задание 2.1:");
            double sum = 0, num = (double)1 / 3;
            for (int i = 0; i <= 8; i++)
            {
                double temp = 1;
                for (int j = 0; j < i; j++)
                {
                    temp *= num;
                }
                sum = sum + temp;
            }
            Console.WriteLine($"Результат: {sum}");
        }

        private static void Num22()
        {
            Console.WriteLine("Задание 2.2:");
            double total = 0, distance100 = 0;
            for (int i = 1; i <= 100; i++)
            {
                double current = (double)1 / i;
                total += current;
                if (i % 2 == 1)
                {
                    distance100 += current;
                }
                else
                {
                    distance100 -= current;
                }
            }
            Console.WriteLine($"Общее пройденное расстояние за 100 итераций: {total} км");
            Console.WriteLine($"Расстояние от дома за 100 итераций: {distance100} км");
        }

        private static void Num23()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Console.WriteLine("Задание 2.3: Чтобы не вводить много циферок, я сгенерировал количества осадков рандомно.");
            byte[] mart = new byte[31];
            short sumMart = 0, sumJan = 0;
            byte[] jan = new byte[31];
            for (int i = 0; i < 31; i++)
            {
                mart[i] = Convert.ToByte(rnd.Next(0, 8));
                sumMart += mart[i];
                jan[i] = Convert.ToByte(rnd.Next(0, 13));
                sumJan += jan[i];
            }
            Console.WriteLine($"Среднее кол-во осаднов в марте: {(double)sumMart / mart.Length}");
            Console.WriteLine($"Среднее кол-во осаднов в январе: {(double)sumJan / jan.Length}");
        }

        private static void Num31()
        {
            Console.WriteLine("Задание #3.1");
            int[,] lastFracs = new int[2, 2]; // Массив с двумя прошлыми числами [0,0]/[0,1] - позапрошлое число; [1,0]/[1,1] - прошлое число
            lastFracs[0, 0] = 1;
            lastFracs[0, 1] = 1;
            lastFracs[1, 0] = 2;
            lastFracs[1, 1] = 1;
            double diff = 1;
            while (diff > 0.0001)
            {
                int currTop = lastFracs[0, 0] + lastFracs[1, 0]; //Числитель нового числа
                int currLow = lastFracs[0, 1] + lastFracs[1, 1]; //Знаменатель нового числа
                diff = Math.Abs(((double)lastFracs[1, 0] / lastFracs[1, 1]) - ((double)currTop / currLow)); //Рассчёт разницы
                //Обновляем массив
                lastFracs[0, 0] = lastFracs[1, 0];
                lastFracs[0, 1] = lastFracs[1, 1];
                lastFracs[1, 0] = currTop;
                lastFracs[1, 1] = currLow;
            }
            Console.WriteLine($"Найденная подходящая дробь: {lastFracs[1, 0]}/{lastFracs[1, 1]} Разница этой дроби с прошлой: {diff}");
        }

        private static void Num32()
        {
            Console.Write("Задание #3.2: Введите число:");
            long userLimit = 0; //Число, которое задаём пользователь
            try
            {
                userLimit = long.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}");
            }
            long inrease = 3;
            long lastNumber = 1;
            while (lastNumber < userLimit)
            {
                lastNumber += inrease;
                inrease += 2;
            }
            Console.WriteLine($"Первое число, большее {userLimit} - это {lastNumber}");
        }

        private static void Num33()
        {
            Console.WriteLine("Задание #3.3: Цикл с предусловием");
            for (int i = 100; i >= 80; i--)
            {
                Console.WriteLine(i);
            }

            //Другой вариант цикла с предусловием:
            //int temp = 100;
            //while (temp >= 80)
            //{
            //    Console.WriteLine(temp--);
            //}

            //Ещё один вариант:
            //int temp = 101;
            //while (temp > 80)
            //{
            //    Console.WriteLine(--temp);
            //}

            Console.WriteLine("Задание #3.3: Цикл с постуловием");
            int temp = 100;
            do
            {
                Console.WriteLine(temp--);
            }
            while (temp >= 80);
        }

        private static void Num34() => Console.WriteLine($"Задание #3.4: Максимальное число (<5000), красное 39: {5000 - 5000 % 39}");

        private static void Num35()
        {
            Console.WriteLine("Задание #3.5-а");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"5 ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Задание #3.5-б");
            for (int i = 5; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"1 ");
                }
                Console.WriteLine();
            }
        }

        private static void Additional()
        {
            byte[] pos1 = new byte[2]; //Первая позиция (a,b)
            byte[] pos2 = new byte[2]; //Вторая позиция (c,d)
            try
            {
                Console.Write("Введите координату x первой фигуры:");
                pos1[0] = byte.Parse(Console.ReadLine());
                Console.Write("Введите координату y первой фигуры:");
                pos1[1] = byte.Parse(Console.ReadLine());
                Console.Write("Введите координату x второй фигуры:");
                pos2[0] = byte.Parse(Console.ReadLine());
                Console.Write("Введите координату y второй фигуры:");
                pos2[1] = byte.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибочка: {ex.Message}");
                return;
            }

            Console.WriteLine("Доп-а");
            if (pos2[0] == pos1[0] || pos2[1] == pos1[1])
            {
                Console.WriteLine($"Ладья на позиции ({pos1[0]};{pos1[1]}) бьёт фигуру на позиции ({pos2[0]};{pos2[1]})");
            }
            else
            {
                Console.WriteLine($"Ладья на позиции ({pos1[0]};{pos1[1]}) НЕ БЬЁТ фигуру на позиции ({pos2[0]};{pos2[1]})");
            }
            Console.WriteLine("Доп-б");
            if (Math.Abs(pos2[0] - pos1[0]) == Math.Abs(pos2[1] - pos1[1]))
            {
                Console.WriteLine($"Слон на позиции ({pos1[0]};{pos1[1]}) бьёт фигуру на позиции ({pos2[0]};{pos2[1]})");
            }
            else
            {
                Console.WriteLine($"Слон на позиции ({pos1[0]};{pos1[1]}) НЕ БЬЁТ фигуру на позиции ({pos2[0]};{pos2[1]})");
            }
            Console.WriteLine("Доп-в");
            if (Math.Abs(pos2[0] - pos1[0]) <= 1 && Math.Abs(pos2[1] - pos1[1]) <= 1)
            {
                Console.WriteLine($"Король на позиции ({pos1[0]};{pos1[1]}) сможет переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            else
            {
                Console.WriteLine($"Король на позиции ({pos1[0]};{pos1[1]}) НЕ СМОЖЕТ переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            Console.WriteLine("Доп-г");
            if (Math.Abs(pos2[0] - pos1[0]) == Math.Abs(pos2[1] - pos1[1]) || pos2[0] == pos1[0] || pos2[1] == pos1[1])
            {
                Console.WriteLine($"Белая пешка на позиции ({pos1[0]};{pos1[1]}) сможет переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            else
            {
                Console.WriteLine($"Белая пешка на позиции ({pos1[0]};{pos1[1]}) НЕ СМОЖЕТ переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            Console.WriteLine("Доп-д");
            if (pos2[1] - pos1[1] == 1)
            {
                Console.WriteLine($"Белая пешка на позиции ({pos1[0]};{pos1[1]}) сможет переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            else
            {
                Console.WriteLine($"Белая пешка на позиции ({pos1[0]};{pos1[1]}) НЕ СМОЖЕТ переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            Console.WriteLine("Доп-е");
            if (pos1[1] - pos2[1] == 1)
            {
                Console.WriteLine($"Чёрная пешка на позиции ({pos1[0]};{pos1[1]}) сможет переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            else
            {
                Console.WriteLine($"Чёрная пешка на позиции ({pos1[0]};{pos1[1]}) НЕ СМОЖЕТ переместиться на ({pos2[0]};{pos2[1]}) за ход");
            }
            Console.WriteLine("Доп-ж");
            if ((Math.Abs(pos1[0] - pos2[0]) == 2 && Math.Abs(pos1[1] - pos2[1]) == 1) || (Math.Abs(pos1[0] - pos2[0]) == 1 && Math.Abs(pos1[1] - pos2[1]) == 2))
            {
                Console.WriteLine($"Конь на позиции ({pos1[0]};{pos1[1]}) бьёт фигуру на позиции ({pos2[0]};{pos2[1]})");
            }
            else
            {
                Console.WriteLine($"Конь на позиции ({pos1[0]};{pos1[1]}) НЕ БЬЁТ фигуру на позиции ({pos2[0]};{pos2[1]})");
            }
        }
    }
}
