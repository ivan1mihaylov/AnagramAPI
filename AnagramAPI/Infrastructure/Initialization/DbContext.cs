using AnagramAPI.Contracts;
using Entity;
using Entity.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AnagramAPI.Infrastructure.Initialization
{
    internal class DbContext : IServicesRegistration
    {
        /// <summary>
        /// Register the different DbContexts and initialize them
        /// </summary>
        /// <param name="services">The service decriptors</param>
        /// <param name="configuration">API settings</param>
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            //SqlLite and MySql
            if(configuration["UseMySql"] == "true")
            {
                services.AddDbContext<AnagramMySqlDbContext>(options => options.UseMySql(configuration.GetConnectionString("InformationDbMysql"), b => b.MigrationsAssembly(typeof(AnagramMySqlDbContext).Assembly.FullName)));

                // Registration of the DbContext as transient service is neccessary for the use of db health checks.
                // There is a workaround by implementing the dbcontext healthchecks by myself but as this is not a actual API I wont waste time on that.
                services.AddTransient<IAnagramDbContext>(c => c.GetRequiredService<AnagramMySqlDbContext>());

                //Migrate the database if UseAutoMigrations is set to true
                if (configuration["UseAutoMigration"] == "true")
                {
                    try
                    {
                        services.BuildServiceProvider().GetService<AnagramMySqlDbContext>().Database.Migrate();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            else
            {
                services.AddDbContext<AnagramSqliteDbContext>(options => options.UseSqlite(configuration.GetConnectionString("InformationDbSqlite"), b => b.MigrationsAssembly(typeof(AnagramSqliteDbContext).Assembly.FullName)));

                // Registration of the DbContext as transient service is neccessary for the use of db health checks.
                // There is a workaround by implementing the dbcontext healthchecks by myself but as this is not a actual API I wont waste time on that.
                services.AddTransient<IAnagramDbContext>(c => c.GetRequiredService<AnagramSqliteDbContext>());

                //Migrate the database if UseAutoMigrations is set to true
                if (configuration["UseAutoMigration"] == "true")
                {
                    try
                    {
                        services.BuildServiceProvider().GetService<AnagramSqliteDbContext>().Database.Migrate();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

        }
    }
}
