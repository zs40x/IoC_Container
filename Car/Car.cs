using System.Diagnostics;

namespace Vehicles
{
    public class Car
    {
        public IEngine Engine { get; private set; }

        public Car(IEngine _engine)
        {
            Engine = _engine;
        }

        public void Start()
        {
            Debug.WriteLine("Car.Start()");
        }
    }
}
