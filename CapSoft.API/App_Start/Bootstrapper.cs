using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;

using System.Reflection;
using System.Web.Http;


using CapSoft.Core.Infrastructure;
using CapSoft.Core.Repositories;
using CapSoft.Core.Mappings;

namespace CapSoft.API
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
         
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
        
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories

            builder.RegisterAssemblyTypes(typeof(UsersRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
                                
            var container = builder.Build();            
            GlobalConfiguration.Configuration.DependencyResolver= new AutofacWebApiDependencyResolver(container);
        }
    }
}