using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest
{
    public static class CollectionTest
    {
        public const int Length = 10000000;
        public const int Loops = 10;
        public static long CreateStaticArray()
        {
            Stopwatch sw = new Stopwatch();
            int[] array = new int[Length];

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                array[i] = i;
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateDynamicList()
        {
            Stopwatch sw = new Stopwatch();
            List<int> list = new List<int>();

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                list.Add(i);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateStaticList()
        {
            Stopwatch sw = new Stopwatch();
            List<int> list = new List<int>(Length);

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                list.Add(i);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateDictionary()
        {
            Stopwatch sw = new Stopwatch();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                dictionary.Add(i, i);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateHashset()
        {
            Stopwatch sw = new Stopwatch();
            HashSet<int> hashset = new HashSet<int>();

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                hashset.Add(i);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void DoWork()
        {
            long staticArray = 0;
            long dynamicList = 0;
            long staticList = 0;
            long dictionary = 0;
            long hashset = 0;
            for (int i = 0; i < Loops; i++)
            {
                staticArray += CreateStaticArray();
                dynamicList += CreateDynamicList();
                staticList += CreateStaticList();
                dictionary += CreateDictionary();
                hashset += CreateHashset();
            }

            Console.WriteLine($"Loops: {Loops}");
            Console.WriteLine($"Статический массив len={Length} заполнился за {staticArray} мс ({staticArray/(double)Loops:f}).");
            Console.WriteLine($"Динамический список len={Length} заполнился за {dynamicList} мс ({dynamicList / (double)Loops:f}).");
            Console.WriteLine($"Статический список len={Length} заполнился за {staticList} мс ({staticList / (double)Loops:f}).");
            Console.WriteLine($"Словарь len={Length} заполнился за {dictionary} мс ({dictionary / (double)Loops:f}).");
            Console.WriteLine($"Hashset len={Length} заполнился за {hashset} мс ({hashset / (double)Loops:f}).");
        }
    }
}
