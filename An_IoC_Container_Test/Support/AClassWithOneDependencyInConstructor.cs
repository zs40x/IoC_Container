using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_IoC_Container_Test.Support
{
    class AClassWithOneDependencyInConstructor : IAnInterface
    {
        public AClassWithOneDependencyInConstructor(IDependency1 dependency1)
        {

        }
    }
}
