using System;
using System.Diagnostics;

namespace Merge
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

        public static void Sort(int[] items)
        {
            if (items.Length <= 1)
            {
                return;
            }

            var leftSize = items.Length/2;
            var rightSize = items.Length - leftSize;
            var left = new int[leftSize];
            var right = new int[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            Sort(left);
            Sort(right);
            Merge(items, left, right);
        }

        private static void Merge(int[] items, int[] left, int[] right)
        {
            var leftIndex = 0;
            var rightIndex = 0;
            var targetIndex = 0;
            var remaining = left.Length + right.Length;
            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
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