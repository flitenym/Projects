using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Factory
{
    public abstract class CarFactoryClass
    {
        public abstract ICar CarFactoryMethod();

        public string GetCarProperties()
        {
            ICar car = CarFactoryMethod();

            return $"Car Name: {car.Name}";
        }
    }
}
