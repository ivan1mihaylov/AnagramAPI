using AnagramAPI.Contracts;
using AnagramAPI.Infrastructure.Configurations;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Initialization
{
    public class AutoMapper : IServicesRegistration
    {
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }

    }
}
