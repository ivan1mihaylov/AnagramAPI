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
            if (configuration["UseMySql"] == "true")
            {
                //Register HealthChecks and UI
                services.AddHealthChecks()
                    .AddCheck("Google Ping", new PingHost("www.google.com", 100))
                    .AddMySql(configuration.GetConnectionString("AuthDbMySql"), "AuthDb Database")
                    .AddDbContextCheck<AnagramMySqlDbContext>();
            }
            else
            {
                //Register HealthChecks and UI
                services.AddHealthChecks()
                    .AddCheck("Google Ping", new PingHost("www.google.com", 100))
                    .AddDbContextCheck<AnagramSqliteDbContext>();
            }

            services.AddHealthChecksUI(configuration.GetConnectionString("HealthChecksDbSqlite"));
        }
    }
}
