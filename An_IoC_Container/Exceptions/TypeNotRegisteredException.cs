using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_IoC_Container.Exceptions
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException()
        { }

        public TypeNotRegisteredException(string msg) : base(msg)
        { }
    }
}
