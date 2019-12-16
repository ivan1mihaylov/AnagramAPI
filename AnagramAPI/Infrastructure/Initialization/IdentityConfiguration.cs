using AnagramAPI.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace AnagramAPI.Infrastructure.Initialization
{
    public class IdentityConfiguration : IServicesRegistration
    {
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["IdentityServerAddress"];
                    options.RequireHttpsMetadata = false;

                    options.Audience = "AnagramAPI";
                });
        }
    }
}
