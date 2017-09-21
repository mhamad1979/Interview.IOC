using My.IOC.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace My.IOC.Web.DependancyInjection
{
    public class IocDependencyResolver : IDependencyResolver
    {
        private IIocContainer container;

        private IDependencyResolver resolver;

        public IocDependencyResolver(IIocContainer container, IDependencyResolver resolver)
        {
            this.container = container;
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch
            {
                return this.resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.resolver.GetServices(serviceType);
        }
    }
}
