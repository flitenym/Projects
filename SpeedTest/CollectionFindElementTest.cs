using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest
{
    public static class CollectionFindElementTest
    {
        public const int Length = 10000;
        public const int Loops = 10;
        public static long ArrayFirstOrDefault()
        {
            int[] array = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                array[i] = i;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < Length; i++)
            {
                int foundedElement = array.FirstOrDefault(x => x == i);
                foundedElement = foundedElement + 1;
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long ListFirstOrDefault()
        {
            List<int> list = new List<int>(Length);

            for (int i = 0; i < Length; i++)
            {
                list.Add(i);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < Length; i++)
            {
                int foundedElement = list.FirstOrDefault(x => x == i);
                foundedElement = foundedElement + 1;
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long ListFind()
        {
            List<int> list = new List<int>(Length);

            for (int i = 0; i < Length; i++)
            {
                list.Add(i);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < Length; i++)
            {
                int foundedElement = list.Find(x => x == i);
                foundedElement = foundedElement + 1;
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long DictionaryByKey()
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < Length; i++)
            {
                dictionary.Add(i, i);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < Length; i++)
            {
                int foundedElement = dictionary[i];
                foundedElement = foundedElement + 1;
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long HashsetTryGetValue()
        {
            HashSet<int> hashset = new HashSet<int>();

            for (int i = 0; i < Length; i++)
            {
                hashset.Add(i);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < Length; i++)
            {
                if (hashset.TryGetValue(i, out int foundedElement))
                {
                    foundedElement = foundedElement + 1;
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void DoWork()
        {
            long arrayFirstOrDefault = 0;
            long listFirstOrDefault = 0;
            long listFind = 0;
            long dictionaryByKey = 0;
            long hashsetTryGetValue = 0;
            for (int i = 0; i < Loops; i++)
            {
                arrayFirstOrDefault += ArrayFirstOrDefault();
                listFirstOrDefault += ListFirstOrDefault();
                listFind += ListFind();
                dictionaryByKey += DictionaryByKey();
                hashsetTryGetValue += HashsetTryGetValue();
            }

            Console.WriteLine($"Loops: {Loops}");
            Console.WriteLine($"ArrayFirstOrDefault len={Length} поиск за {arrayFirstOrDefault} мс ({arrayFirstOrDefault/(double)Loops:f}).");
            Console.WriteLine($"ListFirstOrDefault len={Length} поиск за {listFirstOrDefault} мс ({listFirstOrDefault / (double)Loops:f}).");
            Console.WriteLine($"ListFind len={Length} поиск за {listFind} мс ({listFind / (double)Loops:f}).");
            Console.WriteLine($"DictionaryByKey len={Length} поиск за {dictionaryByKey} мс ({dictionaryByKey / (double)Loops:f}).");
            Console.WriteLine($"HashsetTryGetValue len={Length} поиск за {hashsetTryGetValue} мс ({hashsetTryGetValue / (double)Loops:f}).");
        }
    }
}
