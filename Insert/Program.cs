using System;
using System.Diagnostics;

namespace Insert
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

        public static int FindIndex(ref int[] array, int value)
        {
            for (var index = 0; index < array.Length; index++)
            {
                if (array[index] > value)
                {
                    return index;
                }
            }

            return -1;
        }

        public static void InsertValue(int[] array, int valueIndex, int insertionIndex)
        {
            var temp = array[insertionIndex];
            array[insertionIndex] = array[valueIndex];

            for (var i = valueIndex; i > insertionIndex; i--)
            {
                array[i] = array[i - 1];
            }

            array[insertionIndex + 1] = temp;
        }

        private static void Main(string[] args)
        {
            var array = GetArray();

            var timer = Stopwatch.StartNew();
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    var index = FindIndex(ref array, array[i + 1]);
                    InsertValue(array, i + 1, index);
                }
            }
            timer.Stop();

            Console.WriteLine("Time: {0}", timer.ElapsedTicks);
            PrintArray(array);
        }
    }
}