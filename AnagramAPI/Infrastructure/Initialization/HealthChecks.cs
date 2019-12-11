using AnagramAPI.Contracts;
using AnagramAPI.Infrastructure.HealthChecks;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Initialization
{
    internal class HealthChecks : IServicesRegistration
    {
        /// <summary>
        /// Register health checks for external ping and DbContext access
        /// </summary>
        /// <param name="services">The service decriptors</param>
        /// <param name="configuration">API settings</param>
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            //Register HealthChecks and UI
            services.AddHealthChecksUI();
            services.AddHealthChecks()
                .AddCheck("Google Ping", new PingHost("www.google.com", 100))
                .AddMySql(configuration.GetConnectionString("AuthDb"), "AuthDb Database")
                .AddDbContextCheck<AnagramDbContext>();
        }
    }
}
