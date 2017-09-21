using Microsoft.VisualStudio.TestTools.UnitTesting;
using My.IOC.Library.Implementations;
using System;
using System.Collections.Generic;

namespace My.IOC.Tests.Controllers
{
    [TestClass]
    public class IocTest
    {
 

        [TestMethod]
        public void ResloveMethodTest()
        {
            var container = new IocContainer();

            container.Register<IMappedEntity, ConcreteEntity>();

            var instance = container.Resolve<IMappedEntity>();

            Assert.IsInstanceOfType(instance, typeof(ConcreteEntity));
        }

        [TestMethod]
        public void NotRegisteredException()
        {
            
            var container = new IocContainer();

            Exception exception = null;
            try
            {
                container.Resolve<IMappedEntity>();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsInstanceOfType(exception, typeof(KeyNotFoundException));
        }

        [TestMethod]
        public void ConstructorInjection()
        {
            var container = new IocContainer();

            container.Register<IMappedEntity, ConcreteEntity>();
            container.Register<IMappedEntityWithDependancyInjection, ConcreteEntityWithDependancyInjection>();

            var instance = container.Resolve<IMappedEntityWithDependancyInjection>();
            Assert.IsInstanceOfType(instance, typeof(ConcreteEntityWithDependancyInjection));
        }

        [TestMethod]
        public void LifeCycleTypeSingleton()
        {
            var container = new IocContainer();

            container.Register<IMappedEntity, ConcreteEntity>(Library.Classes.LifeCycleType.Singleton);

            var instance = container.Resolve<IMappedEntity>();
            var anotherInstance = container.Resolve<IMappedEntity>();

            Assert.AreSame(anotherInstance, instance);
        }

        [TestMethod]
        public void LifeCycleTypeTransient()
        {
            var container = new IocContainer();

            //Transient by default
            container.Register<IMappedEntity, ConcreteEntity>();

            var instance = container.Resolve<IMappedEntity>();
            var anotherInstance = container.Resolve<IMappedEntity>();

            Assert.AreNotSame(anotherInstance, instance);
        }
  
    }

    public interface IMappedEntity
    {
    }

    public class ConcreteEntity : IMappedEntity
    {
    }

    public interface IMappedEntityWithDependancyInjection
    {
    }

    public class ConcreteEntityWithDependancyInjection : IMappedEntityWithDependancyInjection
    {
        public ConcreteEntityWithDependancyInjection(IMappedEntity typeToResolve)
        {
        }
    }
}
