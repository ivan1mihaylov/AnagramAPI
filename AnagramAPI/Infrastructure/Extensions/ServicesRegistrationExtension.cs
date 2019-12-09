using AnagramAPI.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Extensions
{
    public static class ServicesRegistrationExtension
    {
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
