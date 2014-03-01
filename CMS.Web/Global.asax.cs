using CMS.Data.DBInteractions;
using CMS.Data.EntityRepositories;
using CMS.Entities;
using CMS.Services;
using CMS.Services.Interfaces;
using CMS.Web.IoC;
using CodeFirstServices.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            IUnityContainer container = GetUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private IUnityContainer GetUnityContainer()
        {
            //Create UnityContainer          
            //IUnityContainer container = new UnityContainer()
            var container = new UnityContainer();
            container.RegisterType<IDBFactory, DBFactory>(new HttpContextLifetimeManager<IDBFactory>());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>());
            container.RegisterType<IDBFactory, DBFactory>(new HttpContextLifetimeManager<IDBFactory>());
            container.RegisterType<ISampleService, SampleService>(new HttpContextLifetimeManager<ISampleService>());
            container.RegisterType<ISampleService2, SampleService2>(new HttpContextLifetimeManager<ISampleService2>());
            //container.RegisterType<typeof(IEntityRepository<>), typeof(EntityRepositoryBase<>)>(new HttpContextLifetimeManager<typeof(IEntityRepository<>)>());
            //container.RegisterType<typeof(IEntityRepository<>), typeof(EntityRepositoryBase<>)>(new HttpContextLifetimeManager<typeof(IEntityRepository<>)>());
            container.RegisterType(typeof(IEntityRepository<>), typeof(EntityRepositoryBase<>));
            container.RegisterType<ISampleRepository, SampleRepository>(new HttpContextLifetimeManager<ISampleRepository>());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //.RegisterType<typeof(IEntityRepository<>), typeof(EntityRepositoryBase<>)>(new HttpContextLifetimeManager<typeof(IEntityRepository<>)>());
            return container;
        }
    }
}
