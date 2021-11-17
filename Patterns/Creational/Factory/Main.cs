using Patterns.Creational.Factory.CarCreators;
using Patterns.Creational.Factory.Cars;
using System;

namespace Patterns.Creational.Factory
{
    public static class Main
    {
        public static string GetResultPattern()
        {
            string result = string.Empty;

            result += $"Создание {nameof(CarMazda)}{Environment.NewLine}";
            result += GetFactoryMessage(new CarCreatorMazda());

            result += $"Создание {nameof(CarNissan)}{Environment.NewLine}";
            result += GetFactoryMessage(new CarCreatorNissan());

            return result;
        }

        private static string GetFactoryMessage(CarFactoryClass carFactoryClass)
        {
            return $"Результат создания через {nameof(CarFactoryClass)}: {carFactoryClass.GetCarProperties()}{Environment.NewLine}";
        }
    }
}
