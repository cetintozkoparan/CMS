using Autofac;
using Autofac.Integration.Mvc;
using CMS.Data.DBInteractions;
using CMS.Services.Interfaces;
using CMS.Web.Controllers;
using CodeFirstServices.Services;
using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          
            var builder = new ContainerBuilder();
            builder.RegisterType<HomeController>().InstancePerHttpRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(Assembly.Load("CMS.Services"))
                 .Where(x => x.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.Load("CMS.Data"))
                 .Where(x => x.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces();

            builder.RegisterType<DBFactory>().As<IDBFactory>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            
            var container = builder.Build(); 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
        }

        
    }
}
