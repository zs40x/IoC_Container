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
            fcut.Register(typeof(IAnInterface), typeof(IASimpleClassWithDefaultConstructor));

            object resolvedInstance = fcut.Resolve(typeof(IAnInterface));

            Assert.IsNotNull(resolvedInstance);

            Assert.IsInstanceOfType(resolvedInstance, typeof(IASimpleClassWithDefaultConstructor));
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException))]
        public void ResolveThrowsExceptionWhenTypeIsNotRegistered()
        {
            object resolvedInstance = fcut.Resolve(typeof(IAnInterface));
        }
    }
}
