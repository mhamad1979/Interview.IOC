using My.IOC.Library.Implementations;
using My.IOC.Web.DependancyInjection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace My.IOC.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new IocContainer();
            IocRegistry.Register(container);
            IDependencyResolver resolver = DependencyResolver.Current;
            DependencyResolver.SetResolver(new IocDependencyResolver(container, resolver));
        }
    }
}
