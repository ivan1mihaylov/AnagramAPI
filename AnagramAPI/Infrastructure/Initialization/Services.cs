using AnagramAPI.Contexts;
using AnagramAPI.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Initialization
{
    /// <summary>
    /// Register the services for DI
    /// </summary>
    internal class Services : IServicesRegistration
    {
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAnagramContext, AnagramContext>();
        }
    }
}
