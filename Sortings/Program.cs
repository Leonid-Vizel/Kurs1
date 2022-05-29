using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sortings
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startGenerate = generate(10000);
            int[] array = new int[startGenerate.Length];
            Stopwatch watch = new Stopwatch();
            List<SortDelegate> sorts = new List<SortDelegate>()
            {
                new SortDelegate(Sorting.BubbleSort),
                new SortDelegate(Sorting.CocktailShakerSort),
                new SortDelegate(Sorting.OddEvenSort),
                new SortDelegate(Sorting.CycleSort),
                new SortDelegate(Sorting.InsertionSort),
                new SortDelegate(Sorting.GnomeSort),
                new SortDelegate(Sorting.SelectionSort),
                new SortDelegate(Sorting.DoubleSelectionSort),
                new SortDelegate(Sorting.ShellSort),
                new SortDelegate(Sorting.RadixSort),
                new SortDelegate(Sorting.HeapSort),
                new SortDelegate(Sorting.QuickSort),
                new SortDelegate(Sorting.CountingSort)
            };
            foreach(SortDelegate sort in sorts)
            {
                Array.Copy(startGenerate, array, startGenerate.Length);
                watch.Start();
                sort.Invoke(array);
                watch.Stop();
                Console.WriteLine($"{sort.Method.Name}: {watch.ElapsedMilliseconds} ms");
                watch.Reset();
            }
            Console.ReadKey();
        }

        public delegate int[] SortDelegate(int[] array);

        private static int[] generate(int length)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(-100000, 100000);
            }
            return array;
        }
    }
}
