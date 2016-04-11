using System;
using System.Diagnostics;

namespace Quick
{
    internal class Program
    {
        private static readonly Random PivotRng = new Random();

        public static void Swap(int[] items, int left, int right)
        {
            var temp = items[left];
            items[left] = items[right];
            items[right] = temp;
        }

        public static void Sort(int[] items)
        {
            QuickSort(items, 0, items.Length - 1);
        }

        private static void QuickSort(int[] items, int left, int right)
        {
            if (left < right)
            {
                var pivotIndex = PivotRng.Next(left, right);
                var newPivot = Partition(items, left, right, pivotIndex);

                QuickSort(items, left, newPivot - 1);
                QuickSort(items, newPivot + 1, right);
            }
        }

        private static int Partition(int[] items, int left, int right, int pivotIndex)
        {
            var pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            var storeIndex = left;

            for (var i = left; i < right; i++)
            {
                if (items[i].CompareTo(pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }


        public static int[] GetArray()
        {
            var array = new int[1000];
            var r = new Random();

            for (var i = 0; i < 1000; i++)
            {
                array[i] = r.Next(1000);
            }

            return array;
        }

        public static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
        }

        private static void Main(string[] args)
        {
            var array = GetArray();

            var timer = Stopwatch.StartNew();
            Sort(array);
            timer.Stop();

            Console.WriteLine("Time: {0}", timer.ElapsedTicks);
            PrintArray(array);
        }
    }
}