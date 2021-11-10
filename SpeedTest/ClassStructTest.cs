using System;
using System.Diagnostics;

namespace SpeedTest
{
    public interface IAnimal
    {
        public int Number { get; set; }
    }

    public class Bird : IAnimal
    {
        public int Number { get; set; }
        public int SecondNumber { get; set; }
    }

    public abstract class Animal
    {
        public int Number { get; set; }
    }

    public class Beast : Animal
    {
        public int SecondNumber { get; set; }
    }

    public class Fish
    {
        public int Number { get; set; }
        public int SecondNumber { get; set; }
    }

    public struct Worm
    {
        public int Number { get; set; }
        public int SecondNumber { get; set; }
    }

    public struct Cat : IAnimal
    {
        public int Number { get; set; }
        public int SecondNumber { get; set; }
    }

    public class Shark : Fish
    {
    }

    public static class ClassStructTest
    {
        public const int Length = 1000000;
        public const int Loops = 100;

        public static long CreateStruct()
        {
            Stopwatch sw = new Stopwatch();
            Worm[] array = new Worm[Length];

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                array[i] = new Worm() { Number = i, SecondNumber = i };
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateStructByInterface()
        {
            Stopwatch sw = new Stopwatch();
            Cat[] array = new Cat[Length];

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                array[i] = new Cat() { Number = i, SecondNumber = i };
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateClass()
        {
            Stopwatch sw = new Stopwatch();
            Fish[] array = new Fish[Length];

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                array[i] = new Fish() { Number = i, SecondNumber = i };
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateClassByClass()
        {
            Stopwatch sw = new Stopwatch();
            Shark[] array = new Shark[Length];

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                array[i] = new Shark() { Number = i, SecondNumber = i };
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateClassByInterface()
        {
            Stopwatch sw = new Stopwatch();
            Bird[] array = new Bird[Length];

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                array[i] = new Bird() { Number = i, SecondNumber = i };
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static long CreateClassByAbstract()
        {
            Stopwatch sw = new Stopwatch();
            Beast[] array = new Beast[Length];

            sw.Start();
            for (int i = 0; i < Length; i++)
            {
                array[i] = new Beast() { Number = i, SecondNumber = i };
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void DoWork()
        {
            long bystruct = 0;
            long structbyinterface = 0;
            long byclass = 0;
            long classbyclass = 0;
            long classbyinterface = 0;
            long classbyabstract = 0;
            for (int i = 0; i < Loops; i++)
            {
                bystruct += CreateStruct();
                structbyinterface += CreateStructByInterface();                
                byclass += CreateClass();
                classbyclass += CreateClassByClass();                
                classbyinterface += CreateClassByInterface();
                classbyabstract += CreateClassByAbstract();
            }

            Console.WriteLine($"Loops: {Loops}");
            Console.WriteLine($"Структура: len={Length} заполнился за {bystruct} мс ({bystruct / (double)Loops:f}).");
            Console.WriteLine($"Структура: реализован интерфейс len={Length} заполнился за {structbyinterface} мс ({structbyinterface / (double)Loops:f}).");
            Console.WriteLine($"Класс: len={Length} заполнился за {byclass} мс ({byclass / (double)Loops:f}).");
            Console.WriteLine($"Класс: унаследован от класса len={Length} заполнился за {classbyclass} мс ({classbyclass / (double)Loops:f}).");
            Console.WriteLine($"Класс: реализован интерфейс len={Length} заполнился за {classbyinterface} мс ({classbyinterface / (double)Loops:f}).");
            Console.WriteLine($"Класс: унаследован от абстрактного len={Length} заполнился за {classbyabstract} мс ({classbyabstract / (double)Loops:f}).");
        }
    }
}