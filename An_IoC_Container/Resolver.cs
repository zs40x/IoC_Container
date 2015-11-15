using An_IoC_Container.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_IoC_Container
{
    public class Resolver
    {
        private Dictionary<Type, Type> typeMap = new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type typeToResolve)
        {
            var typeToInstantiate =
                typeMap.Where(t => t.Key == typeToResolve).FirstOrDefault().Value;

            if (typeToInstantiate == null)
                throw new TypeNotRegisteredException("Type " + typeToResolve.ToString() + " is not registered in the IoC Container");

            var constructor = typeToInstantiate.GetConstructors().First();
            var constructorParameters = constructor.GetParameters();

            if(constructorParameters.Count() == 0)
                return Activator.CreateInstance(typeToInstantiate);

            var dependencyInstances = new List<object>();
            foreach(var parameter in constructorParameters)
                dependencyInstances.Add(Resolve(parameter.ParameterType));

            return constructor.Invoke(dependencyInstances.ToArray());
        }

        public void Register(Type t1, Type t2)
        {
            typeMap.Add(t1, t2);
        }
    }
}
