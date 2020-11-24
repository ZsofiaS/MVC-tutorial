using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        // define a method that will be invoked in Global.asax at app start
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            // register controllers with Autofac
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance();

            var container = builder.Build(); // building the container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}