using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectServer.Core.Data;

namespace ProjectServer.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectServerContext>(o => o.UseSqlServer(configuration.GetConnectionString("ProjectServerConnection"), b => b.MigrationsAssembly("ProjectServer.Core")));
            return services;
        }
    }
}
