using System;
using System.Diagnostics;

namespace Selection
{
    internal class Program
    {
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

        public static int FindMinIndex(int[] array, int fromIndex = 0)
        {
            var minIndex = fromIndex;

            for (var i = fromIndex + 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static void Swap(int[] items, int left, int right)
        {
            var temp = items[left];
            items[left] = items[right];
            items[right] = temp;
        }

        private static void Main(string[] args)
        {
            var array = GetArray();

            var timer = Stopwatch.StartNew();
            for (var i = 0; i < array.Length - 1; i++)
            {
                var minIndex = FindMinIndex(array, i);
                Swap(array, minIndex, i);
            }
            timer.Stop();

            Console.WriteLine("Time: {0}", timer.ElapsedTicks);
            PrintArray(array);
        }
    }
}