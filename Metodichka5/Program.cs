using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Metodichka5
{
    class Program
    {
        private static Random r = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            Num1(args[0]);
            Num2();
            Num3();
            Home1(args[0]);
            Home2();
            Home3();
            Console.ReadKey();
        }

        private static void Num1(string filePath)
        {
            Console.WriteLine("Задание #1");
            char[] input = File.ReadAllText(filePath).ToUpper().ToArray();
            int[] result = countChars(ref input);
            Console.WriteLine($"Всего гласных букв: {result[0]}");
            Console.WriteLine($"Всего согласных букв: {result[1]}");
        }


        #region Num1
        private static int[] countChars(ref char[] charArray)
        {
            char[] vowels = new char[]
            {
                'А','О','У','Э','Ы','Я','Ё','Е','Ю','И',
                'A','E','I','O','U','Y'
            };
            char[] notvowels = new char[]
            {
                'Б','В','Г','Д','Ж','З','Й','К','Л','М','Н','П','Р','С','Т','Ф','Х','Ц','Ч','Ш','Щ',
                'B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T','V','W','X','Z'
            };
            int[] counts = new int[2];
            for (int i = 0; i < charArray.Length; i++)
            {
                if (vowels.Contains(charArray[i]))
                {
                    counts[0]++;
                }
                else if (notvowels.Contains(charArray[i]))
                {
                    counts[1]++;
                }
            }
            return counts;
        }

        private static int[] countChars(List<char> charArray)
        {
            char[] vowels = new char[]
            {
                'А','О','У','Э','Ы','Я','Ё','Е','Ю','И',
                'A','E','I','O','U','Y'
            };
            char[] notvowels = new char[]
            {
                'Б','В','Г','Д','Ж','З','Й','К','Л','М','Н','П','Р','С','Т','Ф','Х','Ц','Ч','Ш','Щ',
                'B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T','V','W','X','Z'
            };
            int[] counts = new int[2];
            for (int i = 0; i < charArray.Count; i++)
            {
                if (vowels.Contains(charArray[i]))
                {
                    counts[0]++;
                }
                else if (notvowels.Contains(charArray[i]))
                {
                    counts[1]++;
                }
            }
            return counts;
        }
        #endregion

        private static void Num2()
        {
            Console.WriteLine("Задание #2");
            int n, m, h;
            Console.Write("Введите кол-во строк в первой матрице: ");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Неверный формат ввода. Повторите ещё раз!");
                Num2();
                return;
            }
            Console.Write("Введите кол-во столбцов в первой матрице: ");
            if (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("Неверный формат ввода. Повторите ещё раз!");
                Num2();
                return;
            }
            Console.Write("Введите кол-во столбцов во второй матрице: ");
            if (!int.TryParse(Console.ReadLine(), out h))
            {
                Console.WriteLine("Неверный формат ввода. Повторите ещё раз!");
                Num2();
                return;
            }
            Console.WriteLine();
            int[,] a = new int[n, m];
            int[,] b = new int[m, h];
            printArray(calculate(ref a, ref b));
        }

        #region Num2
        private static int[,] calculate(ref int[,] a, ref int[,] b)
        {
            Console.WriteLine("Матрица A:");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = r.Next(10);
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матрица B:");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = r.Next(10);
                    Console.Write($"{b[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матрица C = A * B:");
            int[,] c = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                    Console.Write($"{c[i, j]} ");
                }
                Console.WriteLine();
            }
            return c;
        }

        private static LinkedList<LinkedList<int>> calculate(int m, int n, int h)
        {
            //Не думаю, что это лучший способ решения такой задачи :(
            LinkedList<LinkedList<int>> a = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> b = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> c = new LinkedList<LinkedList<int>>();
            Console.WriteLine("Матрица A:");
            for (int i = 0; i < n; i++)
            {
                LinkedList<int> temp = new LinkedList<int>();
                for (int j = 0; j < m; j++)
                {
                    temp.AddLast(r.Next(10));
                    Console.Write($"{temp.Last()} ");
                }
                Console.WriteLine();
                a.AddLast(temp);
            }
            Console.WriteLine("Матрица B(Повёрнута на 90 градусов вправо):");
            for (int i = 0; i < h; i++)
            {
                LinkedList<int> temp = new LinkedList<int>();
                for (int j = 0; j < m; j++)
                {
                    temp.AddFirst(r.Next(10));
                    Console.Write($"{temp.First()} ");
                }
                Console.WriteLine();
                b.AddLast(temp);
            }
            Console.WriteLine("Матрица C = A * B:");
            for (int i = 0; i < n; i++)
            {
                LinkedList<int> fromA = a.First();
                LinkedList<int> temp = new LinkedList<int>();
                for (int j = 0; j < h; j++)
                {
                    int calculate = 0;
                    LinkedList<int> fromB = b.First();
                    b.RemoveFirst();
                    for (int k = 0; k < m; k++)
                    {
                        //Берём два элемента
                        int aFirst = fromA.First();
                        int bFirst = fromB.First();
                        //Считаем
                        calculate += aFirst * bFirst;
                        //Убираем два вхзятых элемента
                        fromA.RemoveFirst();
                        fromB.RemoveFirst();
                        //Добавляем их обратно в конец
                        fromA.AddLast(aFirst);
                        fromB.AddLast(bFirst);
                    }
                    temp.AddLast(calculate);
                    Console.Write($"{temp.Last()} ");
                    b.AddLast(fromB);
                }
                a.RemoveFirst();
                a.AddLast(fromA);
                c.AddLast(temp);
                Console.WriteLine();
            }
            return c;
        }

        private static void printArray(int[,] input)
        {
            Console.WriteLine("\nВывод матрицы");
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Console.Write($"{input[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        private static void Num3()
        {
            Console.WriteLine("Задание #3");
            int[,] temperature = new int[12, 30];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (i == 0 || i == 1 || i == 11)
                    {
                        temperature[i, j] = r.Next(35) * -1;
                    }
                    else
                    {
                        temperature[i, j] = r.Next(35);
                    }
                }
            }
            double[] results = avgs(ref temperature).OrderBy(x => x).ToArray();
            Console.WriteLine("Средние температуры:");
            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i]);
            }
        }

        #region Num3
        private static double[] avgs(ref int[,] months)
        {
            double[] avgs = new double[12];
            for (int i = 0; i < months.GetLength(0); i++)
            {
                double avg = 0;
                for (int j = 0; j < months.GetLength(1); j++)
                {
                    avg += months[i, j];
                }
                avgs[i] = Math.Round(avg / 30, 3);
            }
            return avgs;
        }

        private static Dictionary<string, double> avgsDict(ref int[,] months)
        {
            string[] monthNames = new string[]
            {
                "Январь",
                "Февраль",
                "Март",
                "Апрель",
                "Май",
                "Июнь",
                "Июль",
                "Август",
                "Сентябрь",
                "Октябрь",
                "Ноябрь",
                "Декабрь"
            };
            Dictionary<string, double> temperatures = new Dictionary<string, double>();
            for (int i = 0; i < monthNames.Length; i++)
            {
                temperatures.Add(monthNames[i], 0D);
            }
            for (int i = 0; i < months.GetLength(0); i++)
            {
                double avg = 0;
                for (int j = 0; j < months.GetLength(1); j++)
                {
                    avg += months[i, j];
                }
                temperatures[monthNames[i]] = Math.Round(avg / 30, 3);
            }
            return temperatures;
        }
        #endregion

        private static void Home1(string filePath)
        {
            Console.WriteLine("Задание #1(ДЗ)");
            List<char> input = File.ReadAllText(filePath).ToUpper().ToList();
            int[] result = countChars(input);
            Console.WriteLine($"Всего гласных букв: {result[0]}");
            Console.WriteLine($"Всего согласных букв: {result[1]}");
        }

        private static void Home2()
        {
            Console.WriteLine("Задание #2(ДЗ)");
            int n, m, h;
            Console.Write("Введите кол-во строк в первой матрице: ");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Неверный формат ввода. Повторите ещё раз!");
                Num2();
                return;
            }
            Console.Write("Введите кол-во столбцов в первой матрице: ");
            if (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("Неверный формат ввода. Повторите ещё раз!");
                Num2();
                return;
            }
            Console.Write("Введите кол-во столбцов во второй матрице: ");
            if (!int.TryParse(Console.ReadLine(), out h))
            {
                Console.WriteLine("Неверный формат ввода. Повторите ещё раз!");
                Num2();
                return;
            }
            Console.WriteLine();
            calculate(m, n, h);
        }

        private static void Home3()
        {
            Console.WriteLine("Задание #3(ДЗ)");
            int[,] temperature = new int[12, 30];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (i == 0 || i == 1 || i == 11)
                    {
                        temperature[i, j] = r.Next(35) * -1;
                    }
                    else
                    {
                        temperature[i, j] = r.Next(35);
                    }
                }
            }
            Dictionary<string, double> results = avgsDict(ref temperature);
            Console.WriteLine("Средние температуры:");
            foreach (var pair in results)
            {
                Console.WriteLine($"В месяце {pair.Key} cредняя температура составила {pair.Value}");
            }
        }
    }
}
