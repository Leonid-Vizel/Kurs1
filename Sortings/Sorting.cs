using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    public sealed class Sorting
    {
        #region Methods
        private static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }

        private static int FindMinIndex(int[] array, int start)
        {
            int minpos = start;
            for (int i = start; i < array.Length; i++)
            {
                if (array[i] < array[minpos])
                {
                    minpos = i;
                }
            }
            return minpos;
        }

        private static void FindMaxMinIndex(int[] array, int start, out int minpos, out int maxpos)
        {
            minpos = start;
            maxpos = start;
            for (int i = start; i < array.Length - start; i++)
            {
                if (array[i] < array[minpos])
                {
                    minpos = i;
                }
                if (array[i] > array[maxpos])
                {
                    maxpos = i;
                }
            }
        }

        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        private static void heapify(int[] array, int i)
        {
            int largest = i;
            int l = 2 * (i + 1) - 1;
            int r = 2 * (i + 1);

            if (l < array.Length && array[l] > array[largest])
            {
                largest = l;
            }

            if (r < array.Length && array[r] > array[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                heapify(array, largest);
            }
        }

        static private int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        #endregion

        public static int[] QuickSort(int[] array) => QuickSort(array, 0, array.Length - 1);

        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
            return array;
        }

        public static int[] CocktailShakerSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }

                for (int j = array.Length - 1 - i; j < 0; j--)
                {
                    if (array[i] < array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
            return array;
        }

        public static int[] SelectionSort(int[] array)
        {
            int minIndex = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                minIndex = FindMinIndex(array, i + 1);
                if (array[i] > array[minIndex])
                {
                    Swap(ref array[i], ref array[minIndex]);
                }
            }
            return array;
        }

        public static int[] DoubleSelectionSort(int[] array)
        {
            int minIndex = 0, maxIndex = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                FindMaxMinIndex(array, i + 1, out minIndex, out maxIndex);
                if (array[i] > array[minIndex])
                {
                    Swap(ref array[i], ref array[minIndex]);
                }
                if (minIndex != maxIndex && array[array.Length - 1 - i] < array[maxIndex])
                {
                    Swap(ref array[array.Length - 1 - i], ref array[maxIndex]);
                }
            }
            return array;
        }

        public static int[] CountingSort(int[] array)
        {
            int min, max;
            int lastWrite = -1;
            FindMaxMinIndex(array, 0, out min, out max);
            min = array[min];
            max = array[max];
            int[] counts = new int[Math.Abs(max - min) + 1];
            foreach (int i in array)
            {
                counts[i - min]++;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    for (int j = 0; j < counts[i]; j++)
                    {
                        lastWrite++;
                        array[lastWrite] = i + min;
                    }
                }
            }
            return array;
        }

        public static int[] InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                    }
                }
            }
            return array;
        }

        public static int[] RadixSort(int[] array)
        {
            int i, j;
            int[] tmp = new int[array.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < array.Length; ++i)
                {
                    bool move = (array[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        array[i - j] = array[i];
                    else
                        tmp[j++] = array[i];
                }
                Array.Copy(tmp, 0, array, array.Length - j, j);
            }
            return array;
        }

        public static int[] GnomeSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] < array[i])
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (array[j + 1] < array[j])
                        {
                            Swap(ref array[j + 1], ref array[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return array;
        }

        public static int[] ShellSort(int[] array)
        {
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (array.Length - step); i++)
                {
                    for (int j = i; (j >= 0) && (array[j] > array[j + step]); j -= step)
                    {
                        Swap(ref array[j], ref array[j + step]);
                    }
                }
                step /= 2;
            }
            return array;
        }

        public static int[] OddEvenSort(int[] array)
        {
            bool flag = false;
            while (!flag)
            {
                flag = true;
                for (int i = 1; i < array.Length - 1; i += 2)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        flag = false;
                    }
                }

                for (int i = 0; i < array.Length - 1; i += 2)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        flag = false;
                    }
                }
            }
            return array;
        }

        public static int[] CycleSort(int[] array)
        {
            for (int i = 0; i <= array.Length - 2; i++)
            {
                int temp = array[i], pos = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < temp)
                    {
                        pos++;
                    }
                }

                if (pos == i)
                {
                    continue;
                }

                while (temp == array[pos])
                {
                    pos += 1;
                }

                Swap(ref temp, ref array[pos]);

                while (pos != i)
                {
                    pos = i;

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] < temp)
                        {
                            pos += 1;
                        }
                    }

                    while (temp == array[pos])
                    {
                        pos += 1;
                    }

                    if (temp != array[pos])
                    {
                        Swap(ref temp, ref array[pos]);
                    }
                }
            }

            return array;
        }

        public static int[] HeapSort(int[] array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                heapify(array, i);
            }

            for (int i = array.Length - 1; i > 0; i--)
            {
                Swap(ref array[0], ref array[i]);
                heapify(array, 0);
            }
            return array;
        }
    }
}
