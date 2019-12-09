using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Contracts
{
    interface IServicesRegistration
    {
        void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration);
    }
}
