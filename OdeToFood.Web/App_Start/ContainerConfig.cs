﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        // define a method that will be invoked in Global.asax at app start
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            // register controllers with Autofac
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                .InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build(); // building the container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}