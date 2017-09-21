using My.IOC.Library.Classes;
using My.IOC.Library.Interfaces;
using My.IOC.Web.Controllers;
using My.IOC.Web.Services.Implementations;
using My.IOC.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My.IOC.Web.DependancyInjection
{
    public static class IocRegistry
    {
        public static void Register(IIocContainer container)
        {

            container.Register<HomeController, HomeController>(LifeCycleType.Transiet);
            container.Register<ICustomerService, CustomerService>(LifeCycleType.Transiet);

        }

       
    }
}