using System;
using System.Diagnostics;

namespace Bubble
{
    internal class Program
    {
        public static void Swap(int[] items, int left, int right)
        {
            var temp = items[left];
            items[left] = items[right];
            items[right] = temp;
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
            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        Swap(array, j, i);
                    }
                }
            }
            timer.Stop();

            Console.WriteLine("Time: {0}", timer.ElapsedTicks);
            PrintArray(array);
        }
    }
}