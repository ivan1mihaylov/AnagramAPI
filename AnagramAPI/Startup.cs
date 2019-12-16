using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramAPI.Infrastructure.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AnagramAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServicesInAssembly(Configuration);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //Enable Swagger and SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnagramAPI");
            });


            app.UsePathBase(new PathString("/v1"));

            //Enable HealthChecks and UI
            app.UseRouting();

            //Setup IS authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(config =>
               {
                   config.MapControllers();
                   config.MapHealthChecks("/apiHealth", new HealthCheckOptions
                   {
                       Predicate = _ => true,
                       ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                   });
                   config.MapHealthChecksUI();
               });

        }
    }
}
