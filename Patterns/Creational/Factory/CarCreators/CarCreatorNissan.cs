using Patterns.Creational.Factory.Cars;

namespace Patterns.Creational.Factory.CarCreators
{
    public class CarCreatorNissan : CarFactoryClass
    {
        public override ICar CarFactoryMethod()
        {
            return new CarNissan();
        }
    }
}
