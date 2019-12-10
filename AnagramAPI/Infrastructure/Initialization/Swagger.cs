﻿using AnagramAPI.Contracts;
using AnagramAPI.Infrastructure.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Initialization
{
    internal class Swagger : IServicesRegistration
    {
        /// <summary>
        /// Setup Swagger
        /// </summary>
        /// <param name="services">The service decriptors</param>
        /// <param name="configuration">API settings</param>
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Anagram API", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    Description = "Enter 'Bearer' following by space and JWT.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http
                });

                options.OperationFilter<SwaggerAuthorizeFilter>();
            });
        }
    }
}
