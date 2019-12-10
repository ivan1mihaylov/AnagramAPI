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
    public class HealthChecks : IServicesRegistration
    {
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration config)
        {
            //Register HealthChecks and UI
            services.AddHealthChecksUI();
            services.AddHealthChecks()
                .AddCheck("Google Ping", new PingHost("www.google.com", 100))
                .AddDbContextCheck<AnagramDbContext>();
        }
    }
}
