using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Num1();
            Num2();
            Console.ReadKey();
        }

        private static void Num1()
        {
            Console.WriteLine("Задание 1:");
            //Сгенерируем 50 рандомных элемнтов массива
            Random rnd = new Random(DateTime.Now.Millisecond); ;
            int[] array = new int[50];
            Console.WriteLine("Генерирую массив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(2000);
                Console.Write($"{array[i]} ");
            }
            QuickSort(ref array, 0, array.Length - 1);
            Console.WriteLine("\nСортированный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        private static void Num2()
        {
            Console.WriteLine("Задание 2:");
            Console.Write("Введите кол-во точек (начиная с 0):");
            int amount = 0, input1 = 0, input2 = 0;
            if (!int.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Формат ввода неверный, попробуйте попытку ещё раз!");
                Num2();
                return;
            }
            bool[,] connections = new bool[amount, amount];
            Console.WriteLine("Теперь вводите соединения точек графа. Сначала точка из которой, потом в которую. Если хотите завершить ввод - введите -1 дважды");
            while (int.TryParse(Console.ReadLine(), out input1) && int.TryParse(Console.ReadLine(), out input2))
            {
                if (input1 == -1 || input2 == -1) break;
                connections[input1, input2] = true;
            }
            Console.WriteLine("Ввод завершён! Теперь введите два значения - стартовую и конечную точки:");
            while (!int.TryParse(Console.ReadLine(), out input1))
            {
                Console.WriteLine("Неверна введена стартовая точка, повторите попытку ещё раз!");
            }
            while (!int.TryParse(Console.ReadLine(), out input2))
            {
                Console.WriteLine("Неверна введена конечная точка, повторите попытку ещё раз!");
            }
            Console.WriteLine($"Результат работы DFS: {DFS(ref connections, input1, input2)}");
        }

        private static void QuickSort(ref int[] array, int startIndex, int endIndex)
        {
            int i;
            if (startIndex < endIndex)
            {
                i = Partition(ref array, startIndex, endIndex);

                QuickSort(ref array, startIndex, i - 1);
                QuickSort(ref array, i + 1, endIndex);
            }
        }

        private static int Partition(ref int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }

        private static string DFS(ref bool[,] connections, int startJoint, int endJoint)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startJoint);
            bool[] visited = new bool[connections.GetLength(1)];
            visited[startJoint] = true;
            bool ended = false;
            while (!ended)
            {
                int temp = queue.Dequeue();
                if (temp == endJoint)
                {
                    ended = true;
                }
                else
                {
                    for (int i = 0; i < visited.Length; i++)
                    {
                        if (connections[temp, i] && !visited[i])
                        {
                            queue.Enqueue(i);
                        }
                    }
                    visited[temp] = true;
                }
                if (!ended && queue.Count() == 0)
                {
                    return $"Путь к точке не найден!";
                }
            }
            return FindWayBack(ref visited, ref connections, ref startJoint, ref endJoint);
        }

        private static string FindWayBack(ref bool[] visited, ref bool[,] connections, ref int startJoint, ref int endJoint)
        {
            List<int> path = new List<int>();
            int current = endJoint;
            while (current != startJoint)
            {
                path.Add(current);
                for (int i = visited.Length - 1; i >= 0; i--)
                {
                    if (connections[i, current] && visited[i])
                    {
                        current = i;
                        break;
                    }
                }
            }
            path.Add(0);
            path.Reverse();
            return string.Join("", path);
        }
    }
}
