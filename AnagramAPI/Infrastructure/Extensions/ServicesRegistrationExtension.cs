using AnagramAPI.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Extensions
{
    internal static class ServicesRegistrationExtension
    {
        /// <summary>
        /// Gets all the descendants of IServicesRegistration, 
        /// instancialize them and register the services, as written in InitializeServicesConfiguration of each file
        /// </summary> 
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var appServices = typeof(Startup).Assembly.DefinedTypes
                            .Where(x => typeof(IServicesRegistration).IsAssignableFrom(x) 
                                && !x.IsInterface 
                                && !x.IsAbstract)
                            .Select(Activator.CreateInstance)
                            .Cast<IServicesRegistration>().ToList();

            appServices.ForEach(svc => svc.InitializeServicesConfiguration(services, configuration));
        }
    }
}
