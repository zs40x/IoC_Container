using An_IoC_Container;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace IoC_Container
{
    class CarTest
    {
        private Resolver resolver = new Resolver();

        public CarTest()
        {
            bootstrap();
        }
       
        public void run()
        {
            Car theCar = resolver.Resolve<Car>();

            Debug.WriteLine(theCar.Engine.ToString());
        }


        private void bootstrap()
        {
            resolver.Register(typeof(Car), typeof(Car));
            resolver.Register(typeof(IEngine), typeof(DieselEngine));
        }
    }
}
