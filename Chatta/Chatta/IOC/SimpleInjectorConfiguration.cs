using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Chatta.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Chatta.IOC
{
    internal class SimpleInjectorConfiguration
    {
        public static void ConfigureInjector ()
        {
            // Create the container
            var container = new Container();            
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            RegisterIService(container, typeof(IService));

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterIService(Container container, Type type)
        {
            var assembly = type.Assembly;

            var registrations = assembly.GetExportedTypes()
                .Where(t => t.IsInterface && t != type && type.IsAssignableFrom(t))
                .Select(t => new
                 {
                     Interface = t
                 })
                .ToList();

            registrations.ForEach(r =>
            {
                var implementation = assembly.GetTypes().FirstOrDefault(c => r.Interface.IsAssignableFrom(c) && !c.IsInterface);

                if (implementation != null)
                {
                    container.Register(r.Interface, implementation, Lifestyle.Transient);
                }                
            });
        }
    }
}