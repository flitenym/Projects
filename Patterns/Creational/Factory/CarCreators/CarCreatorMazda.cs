using Patterns.Creational.Factory.Cars;

namespace Patterns.Creational.Factory.CarCreators
{
    public class CarCreatorMazda : CarFactoryClass
    {
        public override ICar CarFactoryMethod()
        {
            return new CarMazda();
        }
    }
}
