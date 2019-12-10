using AnagramAPI.Contracts;
using Entity;
using Entity.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnagramAPI.Infrastructure.Initialization
{
    public class DbContext : IServicesRegistration
    {
        public void InitializeServicesConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AnagramDbContext>(options => options.UseMySql(configuration.GetConnectionString("InformationDb")));
            // Registration of the DbContext as transient service is neccessary for the use of db health checks.
            // There is a workaround by implementing the dbcontext healthchecks by myself but as this is not a actual API I wont waste time on that.
            services.AddTransient<IAnagramDbContext>(c => c.GetRequiredService<AnagramDbContext>());
        }
    }
}
