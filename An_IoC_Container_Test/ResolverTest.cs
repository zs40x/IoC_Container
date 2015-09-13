using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using An_IoC_Container;
using An_IoC_Container_Test.Support;
using An_IoC_Container.Exceptions;

namespace An_IoC_Container_Test
{
    [TestClass]
    public class ResolverTest
    {
        private Resolver fcut;

        [TestInitialize]
        public void TestInitialize()
        {
            fcut = new Resolver();
        }

        [TestMethod]
        public void ResolvesASimpleClassWithDefaultConstructor()
        {
            fcut.Register(typeof(IAnInterface), typeof(ASimpleClassWithDefaultConstructor));

            object resolvedInstance = fcut.Resolve<IAnInterface>();

            Assert.IsNotNull(resolvedInstance);

            Assert.IsInstanceOfType(resolvedInstance, typeof(ASimpleClassWithDefaultConstructor));
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException))]
        public void ResolveThrowsExceptionWhenTypeIsNotRegistered()
        {
            object resolvedInstance = fcut.Resolve(typeof(IAnInterface));
        }

        [TestMethod]
        public void ResolvesAClassWithAConstructorDependency()
        {
            fcut.Register(typeof(IAnInterface), typeof(AClassWithOneDependencyInConstructor));
            fcut.Register(typeof(IDependency1), typeof(Dependency1));

            object resolvedInstance = fcut.Resolve(typeof(IAnInterface));

            Assert.IsNotNull(resolvedInstance);

            Assert.IsInstanceOfType(resolvedInstance, typeof(AClassWithOneDependencyInConstructor));
        }
    }
}
